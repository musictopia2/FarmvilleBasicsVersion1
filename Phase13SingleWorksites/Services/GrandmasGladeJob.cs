namespace Phase13SingleWorksites.Services;
public class GrandmasGladeJob
{
    //for now, this is only grandmas glade.  will later be other jobs too (rethinking).
    public DateTime? StartedAt { get; private set; }
    public EnumWorksiteState Status { get; set; } = EnumWorksiteState.None;
    public TimeSpan Duration { get; } = TimeSpan.FromSeconds(30); //normally 15 minutes but has to be less time or can't easily test.  pond will be 2 minutes later for testing.
    //hint:  if a person chooses another worker and they already are maxed out, then replaces the first one chosen.
    public int MaximumWorkers => 2;
    public BasicList<WorkerModel> Workers { get; private set; } = [];
    private WorksiteJobContext? _context;
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
    public void AddWorker(WorkerModel worker)
    {
        if (Workers.Count >= MaximumWorkers)
        {
            Workers.RemoveFirstItem();
        }
        Workers.Add(worker);
    }
    public void RemoveWorker(WorkerModel worker)
    {
        Workers.RemoveSpecificItem(worker);
    }
    public BasicList<ItemAmount> SuppliesNeeded
    {
        get
        {
            return
                [
                new(EnumItemType.Biscuits, 1)
                ];
        }
    }
    public bool CanStartJob(Inventory inventory)
    {
        if (inventory.Has(EnumItemType.Biscuits, 1) == false)
        {
            return false;
        }
        return Status == EnumWorksiteState.None && Workers.Count > 0;
    }
    //public bool CanStartJob => Status == EnumWorksiteState.None && Workers.Count > 0;
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
        inventory.Consume(EnumItemType.Biscuits, 1); //i think this is wher it belongs
        BasicList<EnumWorkerType> list = Workers.Select(x => x.WorkerType).ToBasicList();
        _context = new()
        {
            Workers = list
        };
        Workers.ForEach(worker => worker.WorkerStatus = EnumWorkerStatus.Working);
        StartedAt = DateTime.Now;
        Status = EnumWorksiteState.Processing;
    }
    private static bool ShouldAward(double chance) => chance >= 1 || Random.Shared.NextDouble() <= chance;
    public BasicList<ItemAmount> GetRewards()
    {
        if (CanCollectRewards == false)
        {
            throw new CustomBasicException("Cannot collect rewards because there was none to collect.  Should had ran CanCollectRewards");
        }
        var possibleList = GrandmasGladeDefinition.Output;
        CustomBasicException.ThrowIfNull(_context);
        BasicList<ItemAmount> output = [];
        foreach (var item in possibleList)
        {
            CustomBasicException.ThrowIfNull(item.Value.CalculateChance);
            CustomBasicException.ThrowIfNull(item.Value.CalculateAmount);
            int amount = item.Value.CalculateAmount(_context);
            if (amount == 0)
            {
                continue;
            }
            double chances = item.Value.CalculateChance(_context);
            if (chances == 0)
            {
                continue;
            }
            if (ShouldAward(chances))
            {
                output.Add(new ItemAmount()
                {
                    Amount = amount,
                    Item = item.Key
                });
            }
        }
        return output;
    }
    public bool HasCollectedAllRewards => _rewards.Count == 0;
    public void CollectAllRewards()
    {
        _rewards.Clear();
        _context = null;
        foreach (var item in Workers)
        {
            item.WorkerStatus = EnumWorkerStatus.None; //they are no longer working because all rewards has been collected.
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
    public BasicList<WorksiteRewardPreview> GetPreview()
    {
        BasicList<EnumWorkerType> list = Workers.Select(x => x.WorkerType).ToBasicList();
        var ctx = new WorksiteJobContext() { Workers = list };
        BasicList<WorksiteRewardPreview> result = [];
        foreach (var kvp in GrandmasGladeDefinition.Output)
        {
            var output = kvp.Value;

            // Calculate current amount and chance
            int amount = output.CalculateAmount?.Invoke(ctx) ?? 0;
            double chance = output.CalculateChance?.Invoke(ctx) ?? 0;
            if (ctx.Workers.Count == 0)
            {
                chance = 0; //you can't have any chance of something without a worker.
            }
            if (kvp.Value.Original == false && ctx.Workers.Count == 0)
            {
                continue; //can't even add because it did not come with it and no workers.
            }
            if (chance == 0 && kvp.Value.Original == false)
            {
                continue; //still has to continue because can't add since it did not come with it and the chances are 0.
            }
            if (amount == 0)
            {
                continue;
            }
            if (ctx.Workers.Count > 0 && chance == 0)
            {
                throw new CustomBasicException("At this point, has to have at least a small chance.  Rethink");
            }
            result.Add(new WorksiteRewardPreview
            {
                Item = kvp.Key,
                Amount = amount,
                Chance = chance * 100, //the component excepts in percent form.
            });
        }
        return result;
    }
}