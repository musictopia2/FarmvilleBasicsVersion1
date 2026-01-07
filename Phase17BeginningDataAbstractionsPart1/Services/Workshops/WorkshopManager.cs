namespace Phase17BeginningDataAbstractionsPart1.Services.Workshops;
public class WorkshopManager(Inventory inventory,
    IWorkshopRegistry workshopRecipes,
    IWorkshopInstances workshopInstances)
{
    private readonly BasicList<WorkshopInstance> _workshops = [];
    private BasicList<WorkshopRecipe> _recipes = [];
    public object Lock = new();
    private WorkshopInstance GetWorkshopById(Guid id)
    {
        var workshop = _workshops.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Workshop with Id {id} not found.");
        return workshop;
    }
    private WorkshopInstance GetWorkshopById(WorkshopSummary id) => GetWorkshopById(id.Id);
    public BasicList<WorkshopSummary> GetAllWorkshops
    {
        get
        {
            BasicList<WorkshopSummary> output = [];
            _workshops.ForEach(t =>
            {
                WorkshopSummary summary = new()
                {
                    Id = t.Id,
                    Name = t.BuildingName
                };
                output.Add(summary);
            });
            return output;
        }
    }
    public BasicList<WorkshopRecipeSummary> GetRecipesForWorkshop(WorkshopSummary summary)
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
    public bool AnyInQueue(WorkshopSummary summary)
    {
        lock (Lock)
        {
            WorkshopInstance workshop = GetWorkshopById(summary);
            return workshop.Queue.Count != 0;
        }
    }
    public BasicList<CraftingSummary> GetItemsBeingCrafted(WorkshopSummary summary)
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
    public bool CanCraft(WorkshopSummary summary, string item)
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
    public void StartCraftingJob(WorkshopSummary summary, string item)
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
    public async Task PopulateWorkshopsAsync()
    {
        _recipes = await workshopRecipes.GetWorkshopRecipesAsync();
        var ours = await workshopInstances.GetWorkshopInstancesAsync();
        foreach (var item in ours)
        {
            _workshops.Add(new()
            {
                BuildingName = item.Name,
                Capacity = item.Capcity
            });
        }
    }
    public void UpdateTick()
    {
        _workshops.ForEach(ProcessBuilding);
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