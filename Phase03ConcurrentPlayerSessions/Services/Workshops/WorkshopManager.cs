namespace Phase03ConcurrentPlayerSessions.Services.Workshops;
public class WorkshopManager(Inventory inventory
    )
{
    private IWorkshopPolicy? _workshopPolicy;
    private readonly BasicList<WorkshopInstance> _workshops = [];
    private BasicList<WorkshopRecipe> _recipes = [];
    public event Action? OnWorkshopsUpdated;
    public object Lock = new();
    private WorkshopInstance GetWorkshopById(Guid id)
    {
        var workshop = _workshops.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Workshop with Id {id} not found.");
        return workshop;
    }
    private WorkshopInstance GetWorkshopById(WorkshopView id) => GetWorkshopById(id.Id);
    public BasicList<WorkshopView> GetUnlockedWorkshops
    {
        get
        {
            lock (Lock)
            {
                BasicList<WorkshopView> output = [];
                _workshops.ForConditionalItems(x => x.Unlocked, t =>
                {
                    WorkshopView summary = new()
                    {
                        Id = t.Id,
                        Name = t.BuildingName,
                    };
                    output.Add(summary);

                });
                return output;
            }
        }
    }
    public BasicList<WorkshopState> GetAllWorkshops
    {
        get
        {
            lock (Lock)
            {
                BasicList<WorkshopState> output = [];
                _workshops.ForEach(t =>
                {
                    bool remaining = false;
                    if (t.Queue.Any(x => x.State != EnumWorkshopState.Completed))
                    {
                        remaining = true;
                    }
                    WorkshopState summary = new()
                    {
                        Id = t.Id,
                        Name = t.BuildingName,
                        Unlocked = t.Unlocked,
                        RemainingCraftingJobs = remaining
                    };
                    output.Add(summary);
                });
                return output;
            }

        }
    }
    public async Task<bool> CanUnlockWorkshopAsync(string name)
    {
        if (_workshopPolicy is null)
        {
            return false;
        }
        var list = GetAllWorkshops;
        var policy = await _workshopPolicy.CanUnlockAsync(list, name);
        return policy;
    }
    public async Task UnlockWorkshopAsync(string name)
    {
        var list = GetAllWorkshops;
        var policy = await _workshopPolicy!.UnlockAsync(list, name);
        UpdateWorkshopInstance(policy);
    }
    public async Task<bool> CanLockWorkshopAsync(string name)
    {
        if (_workshopPolicy is null)
        {
            return false;
        }
        var list = GetAllWorkshops;
        var policy = await _workshopPolicy!.CanLockAsync(list, name);
        return policy;
    }
    public async Task LockWorkshopAsync(string name)
    {

        var list = GetAllWorkshops;
        var policy = await _workshopPolicy!.LockAsync(list, name);
        UpdateWorkshopInstance(policy);
    }
    private void UpdateWorkshopInstance(WorkshopState summary)
    {
        var workshop = GetWorkshopById(summary);
        workshop.Unlocked = summary.Unlocked;
        OnWorkshopsUpdated?.Invoke();
    }
    public BasicList<WorkshopRecipeSummary> GetRecipesForWorkshop(WorkshopView summary)
    {
        return _recipes
            .Where(r => r.BuildingName == summary.Name)
            .Select(r => new WorkshopRecipeSummary
            {
                Item = r.Item,
                Inputs = r.Inputs,
                Output = r.Output,
                Duration = r.Duration
            })
            .ToBasicList();
    }
    public bool AnyInQueue(WorkshopView summary)
    {
        lock (Lock)
        {
            WorkshopInstance workshop = GetWorkshopById(summary);
            return workshop.Queue.Count != 0;
        }
    }
    public BasicList<CraftingSummary> GetItemsBeingCrafted(WorkshopView summary)
    {
        lock (Lock)
        {
            WorkshopInstance workshop = GetWorkshopById(summary);
            BasicList<CraftingSummary> output = [];
            foreach (var job in workshop.Queue)
            {
                CraftingSummary craftSummary = new()
                {
                    Id = job.Id,
                    Name = job.Recipe.Item,
                    State = job.State,
                    ReadyTime = job.State == EnumWorkshopState.Completed
                        ? "Ready"
                        : job.State == EnumWorkshopState.Waiting
                            ? "Waiting"
                            : job.ReadyTime?.GetTimeString!
                };
                output.Add(craftSummary);
            }
            return output;
        }
    }
    public bool CanCraft(WorkshopView summary, string item)
    {
        lock (Lock)
        {
            WorkshopRecipe recipe = _recipes.Single(x => x.Item == item);
            if (recipe.BuildingName != summary.Name)
            {
                return false;
            }
            WorkshopInstance workshop = GetWorkshopById(summary);
            if (workshop.CanAccept(recipe) == false)
            {
                return false;
            }
            return inventory.Has(recipe.Inputs);
        }
    }
    public void StartCraftingJob(WorkshopView summary, string item)
    {
        lock (Lock)
        {
            if (CanCraft(summary, item) == false)
            {
                throw new CustomBasicException("Unable to craft.  Should had ran the CanCraft first");
            }
            WorkshopRecipe recipe = _recipes.Single(x => x.Item == item);
            inventory.Consume(recipe.Inputs);
            CraftingJob job = new(recipe);
            WorkshopInstance workshop = GetWorkshopById(summary);
            workshop.Queue.Add(job);
        }
    }
    public async Task SetStyleContextAsync(WorkshopServicesContext context)
    { 
        _workshopPolicy = context.WorkshopPolicy;
        _recipes = await context.WorkshopRegistry.GetWorkshopRecipesAsync();
        var ours = await context.WorkshopInstances.GetWorkshopInstancesAsync();
        _workshops.Clear();
        foreach (var item in ours)
        {
            _workshops.Add(new()
            {
                BuildingName = item.Name,
                Capacity = item.Capcity,
                Unlocked = item.Unlocked
            });
        }
    }
    public void UpdateTick()
    {
        _workshops.ForConditionalItems(x => x.Unlocked, ProcessBuilding);
    }
    private void ProcessBuilding(WorkshopInstance workshop)
    {
        // 1. Start waiting job if no active job
        var active = workshop.Queue.FirstOrDefault(j => j.State == EnumWorkshopState.Active);
        if (active == null)
        {
            var next = workshop.Queue.FirstOrDefault(j => j.State == EnumWorkshopState.Waiting);
            next?.Start();
            active = next;
        }

        // 2. Complete active job if time elapsed
        if (active != null && DateTime.Now - active.StartedAt >= active.Recipe.Duration)
        {
            active.Complete();
            // Add recipe output to inventory
            inventory.Add(active.Recipe.Output.Item, active.Recipe.Output.Amount);

            // Optional: add extra outputs if you support them
            //foreach (var extra in active.Job.Recipe.ExtraOutputs)
            //{
            //    _inventory.Add(extra.Item, extra.Amount);
            //}
        }

        // 3. Prune completed jobs older than 1 minute
        workshop.Queue.RemoveAllAndObtain(j => j.State == EnumWorkshopState.Completed &&
                                      (DateTime.Now - (j.CompletedAt ?? DateTime.Now)) > TimeSpan.FromSeconds(5));
    }
}