namespace Phase04Part1AdvancedCrafting.Services;
public class GameState : IGameTimer
{
    readonly RecipeRegistry _register;
    readonly Inventory _inventory;
    //go ahead and hard code 2 classes for the 2 buildings.
    readonly Windmill _wind;
    readonly PastryOven _pastry;
    public object Lock = new();

    public Windmill Windmill => _wind;
    public PastryOven PastryOven => _pastry;

    public GameState()
    {
        _register = new();
        _inventory = new();
        _inventory.Add(EnumItemType.Wheat, 11);
        _inventory.Add(EnumItemType.Milk, 3);
        _inventory.Add(EnumItemType.Apples, 6);
        _inventory.Add(EnumItemType.Corn, 5);
        _wind = new();
        _pastry = new();

    }
    public int GetInventoryCount(EnumItemType item)
    {
        return _inventory.Get(item);
    }
    public RecipeModel GetRecipe(EnumItemType item)
    {
        return _register.GetByName(item);
    }
    public bool HasPartialRequirement(EnumItemType item, int amountNeeded) => _inventory.Has(item, amountNeeded);
    public bool CanCraftFromWindmill(EnumItemType item)
    {
        lock (Lock)
        {
            RecipeModel recipe = _register.GetByName(item);
            if (recipe.Building != EnumBuildingCategory.Windmill)
            {
                return false;
            }
            if (_wind.CanAccept(recipe) == false)
            {
                return false;
            }
            return _inventory.Has(recipe.Inputs);
        }
    }
    public void StartWindmillJob(EnumItemType item)
    {
        if (CanCraftFromWindmill(item) == false)
        {
            throw new CustomBasicException("Unable to craft.  Should had ran the CanCraftFromWindmill first");
        }
        RecipeModel recipe = _register.GetByName(item);
        _inventory.Consume(recipe.Inputs);
        StateChanged?.Invoke();
        CraftingJob job = new (recipe);
        _wind.Queue.Add(job);
    }

    public bool CanCraftFromPastryOven(EnumItemType item)
    {
        lock (Lock)
        {
            RecipeModel recipe = _register.GetByName(item);
            if (recipe.Building != EnumBuildingCategory.PastryOven)
            {
                return false;
            }
            if (_pastry.CanAccept(recipe) == false)
            {
                return false;
            }
            return _inventory.Has(recipe.Inputs);
        }   
    }
    public void StartPastryOvenJob(EnumItemType item)
    {
        if (CanCraftFromPastryOven(item) == false)
        {
            throw new CustomBasicException("Unable to craft.  Should had ran the CanCraftFromPastryOven first");
        }
        RecipeModel recipe = _register.GetByName(item);
        _inventory.Consume(recipe.Inputs);
        StateChanged?.Invoke();
        CraftingJob job = new(recipe);
        _pastry.Queue.Add(job);
    }
    void IGameTimer.Tick()
    {
        ProcessBuilding(_wind);
        ProcessBuilding(_pastry);
    }
    public Func<Task>? StateChanged { get; set; }
    private void ProcessBuilding(Building building)
    {
        // 1. Start waiting job if no active job
        var active = building.Queue.FirstOrDefault(j => j.State == EnumJobState.Active);
        if (active == null)
        {
            var next = building.Queue.FirstOrDefault(j => j.State == EnumJobState.Waiting);
            next?.Start();
            active = next;
        }

        // 2. Complete active job if time elapsed
        if (active != null && DateTime.Now - active.StartedAt >= active.Recipe.Duration)
        {
            active.Complete();
            // Add recipe output to inventory
            _inventory.Add(active.Recipe.Output.Item, active.Recipe.Output.Amount);
            StateChanged?.Invoke();

            // Optional: add extra outputs if you support them
            //foreach (var extra in active.Job.Recipe.ExtraOutputs)
            //{
            //    _inventory.Add(extra.Item, extra.Amount);
            //}
        }

        // 3. Prune completed jobs older than 1 minute
        building.Queue.RemoveAllAndObtain(j => j.State == EnumJobState.Completed &&
                                      (DateTime.Now - (j.CompletedAt ?? DateTime.Now)) > TimeSpan.FromMinutes(1));
    }
}