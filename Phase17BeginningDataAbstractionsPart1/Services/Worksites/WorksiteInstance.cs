namespace Phase17BeginningDataAbstractionsPart1.Services.Worksites;
public class WorksiteInstance(WorksiteRecipe recipe)
{
    public const string NoneLocation = "None";
    public string Location => recipe.Location;
    public TimeSpan Duration => recipe.Duration;
    public DateTime? StartedAt { get; private set; }
    public EnumWorksiteState Status { get; set; } = EnumWorksiteState.None;
    public int MaximumWorkers => recipe.MaximumWorkers;
    public BasicList<WorkerModel> Workers { get; private set; } = [];
    private BasicList<ItemAmount> _rewards = [];
    public TimeSpan? ReadyTime
    {
        get
        {
            if (Status != EnumWorksiteState.Processing || StartedAt is null)
            {
                return null;
            }
            var elapsed = DateTime.Now - StartedAt.Value;
            var remaining = Duration - elapsed;
            return remaining > TimeSpan.Zero
                ? remaining
                : TimeSpan.Zero;
        }
    }
    public string StartText => recipe.StartText;
    public void AddWorker(WorkerModel worker)
    {
        if (Workers.Count >= MaximumWorkers)
        {
            var temp = Workers.First();
            FreeWorker(temp);
            Workers.RemoveFirstItem();
        }
        worker.WorkerStatus = EnumWorkerStatus.Selected;
        worker.CurrentLocation = recipe.Location;
        Workers.Add(worker);
    }
    private static void FreeWorker(WorkerModel worker)
    {
        worker.WorkerStatus = EnumWorkerStatus.None;
        worker.CurrentLocation = NoneLocation;
    }
    public void RemoveWorker(WorkerModel worker)
    {
        FreeWorker(worker);
        Workers.RemoveSpecificItem(worker);
    }
    public BasicList<ItemAmount> SuppliesNeeded
    {
        get
        {
            BasicList<ItemAmount> output = [];
            foreach (var item in recipe.Inputs)
            {
                output.Add(new ItemAmount(item.Key, item.Value));
            }
            return output;
        }
    }
    public bool CanStartJob(Inventory inventory)
    {
        if (inventory.Has(recipe.Inputs) == false)
        {
            return false;
        }
        return Status == EnumWorksiteState.None && Workers.Count > 0;
    }
    public bool CanCollectRewards => Status == EnumWorksiteState.Collecting;
    public void StoreRewards(BasicList<ItemAmount> rewards)
    {
        _rewards = rewards;
    }
    public void StartJob(Inventory inventory)
    {
        _rewards.Clear();
        if (CanStartJob(inventory) == false)
        {
            throw new CustomBasicException("Unable to start job.  Should had called CanStartJob first");
        }
        foreach (var item in recipe.Inputs)
        {
            inventory.Consume(item.Key, item.Value);
        }
        Workers.ForEach(worker => worker.WorkerStatus = EnumWorkerStatus.Working);
        StartedAt = DateTime.Now;
        Status = EnumWorksiteState.Processing;
    }
    private static bool ShouldAward(double chance) => chance >= 1 || Random.Shared.NextDouble() <= chance;
    public BasicList<ItemAmount> GetRewards() //todo
    {
        if (CanCollectRewards == false)
        {
            throw new CustomBasicException("Cannot collect rewards because there was none to collect.  Should had ran CanCollectRewards");
        }
        BasicList<WorksiteRewardPreview> list = GetPreview(false);
        BasicList<ItemAmount> output = [];
        foreach (var item in list)
        {
            if (ShouldAward(item.Chance))
            {
                output.Add(new(item.Item, item.Amount));
            }
        }
        return output;
    }
    public bool HasCollectedAllRewards => _rewards.Count == 0;
    public void CollectAllRewards()
    {
        _rewards.Clear();
        //_context = null;
        foreach (var item in Workers)
        {
            FreeWorker(item);
        }
        Workers.Clear();
        StartedAt = null;
        Status = EnumWorksiteState.None; //needs to be none here too.
    }
    public void UpdateTick()
    {
        if (Status != EnumWorksiteState.Processing || StartedAt == null)
        {
            return;
        }
        var elapsed = DateTime.Now - StartedAt.Value;
        if (elapsed >= Duration)
        {
            Status = EnumWorksiteState.Collecting;
            StartedAt = null;
        }
    }

    public BasicList<WorksiteRewardPreview> GetPreview(bool uiOnly = true)
    {
        BasicList<WorksiteRewardPreview> output = [];
        WorksiteRewardPreview preview;
        if (Workers.Count == 0)
        {
            foreach (var firsts in recipe.BaselineBenefits)
            {
                double chance;
                if (firsts.Guarantee)
                {
                    chance = 1;
                }
                else
                {
                    chance = firsts.Chance;
                }
                preview = new()
                {
                    Chance = chance,
                    Amount = firsts.Quantity,
                    Item = firsts.Item
                };
                output.Add(preview);
            }
            return output;
        }

        HashSet<string> candidateItems = [];

        foreach (var b in recipe.BaselineBenefits)
        {
            candidateItems.Add(b.Item);
        }

        foreach (var worker in Workers)
        {
            foreach (var benefit in worker.Benefits)
            {
                if (benefit.Worksite == recipe.Location)
                {
                    candidateItems.Add(benefit.Item);
                }
            }
        }
        foreach (var review in candidateItems)
        {
            WorksiteBaselineBenefit? startBenefit = recipe.BaselineBenefits.SingleOrDefault(x => x.Item == review);
            BasicList<WorkerBenefit> workerBenefits = GetWorkerBenefits(review);
            if (workerBenefits.Count == 0 && startBenefit is null)
            {
                continue;
            }
            int amount = startBenefit?.Quantity ?? 0;
            if (workerBenefits.Any(x => x.GivesExtra))
            {
                amount++;
            }
            if (startBenefit is null)
            {
                amount = 1; //i think must give 1 because there is no start benefit.
            }
            double chances;
            if (startBenefit is not null && startBenefit.Guarantee)
            {
                chances = 1;
            }
            else if (workerBenefits.Any(x => x.Guarantee))
            {
                chances = 1;
            }
            else
            {
                double startBase = startBenefit?.Chance ?? 0;
                double baseChance = startBase * Workers.Count;
                double extras = workerBenefits.Sum(x => x.ChanceModifier);
                chances = baseChance + extras;
            }
            if (chances > 1)
            {
                chances = 1;
            }
            if (chances == 0)
            {
                throw new CustomBasicException($"Must have at least a small chance or why bother including {review}");
            }
            if (uiOnly)
            {
                chances *= 100;
            }
            preview = new()
            {
                Item = review,
                Amount = amount,
                Chance = chances
            };
            output.Add(preview);
        }
        return output;
    }
    private BasicList<WorkerBenefit> GetWorkerBenefits(string item)
    {
        BasicList<WorkerBenefit> output = [];
        Workers.ForConditionalItems(x => x.CurrentLocation == recipe.Location, worker =>
        {
            var seconds = worker.Benefits.Where(x => x.Item == item);
            output.AddRange(seconds);
        });
        return output;
    }
}