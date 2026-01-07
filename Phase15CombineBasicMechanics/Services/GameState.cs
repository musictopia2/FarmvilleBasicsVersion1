namespace Phase15CombineBasicMechanics.Services;
public class GameState : IGameTimer
{
    public object Lock = new();
    public const int TotalFromTrees = 4;
    readonly Inventory _inventory;
    readonly WorksiteInstance _grandma;
    readonly WorksiteInstance _pond;
    readonly WorksiteRegistry _worksiteRegistry;
    readonly WorkerRegistry _workers;
    readonly TreeRegistry _treeRegistry;
    readonly TreeInstance _appleInstance;
    readonly TreeInstance _peachInstance;
    readonly AnimalRegistry _animalRegistry;
    readonly AnimalInstance _cowInstance;
    readonly AnimalInstance _chickenInstance;
    readonly BuildingRecipeRegistry _buildingRecipe;
    readonly Windmill _wind;
    readonly PastryOven _pastry;
    public Windmill Windmill => _wind;
    public PastryOven PastryOven => _pastry;
    public BasicList<CropInstance> CropInstances { get; private set; } = [];
    private readonly CropRegistry _cropRegistry;
    public GameState()
    {
        _inventory = new();
        _inventory.Add(EnumItemType.Wheat, 10);
        _inventory.Add(EnumItemType.Corn, 10);
        _inventory.Add(EnumItemType.Shrimp, 10);
        _inventory.Add(EnumItemType.Honey, 10);
        _worksiteRegistry = new();
        _workers = new();
        WorksiteRecipe recipe1 = _worksiteRegistry.ForWorksite(EnumWorksiteLocation.GrandmasGlade);
        _grandma = new(recipe1);
        recipe1 = _worksiteRegistry.ForWorksite(EnumWorksiteLocation.Pond);
        _pond = new(recipe1);
        _treeRegistry = new();
        TreeRecipe recipe2 = _treeRegistry.GetByName(EnumItemType.Apples);
        _appleInstance = new(recipe2);
        recipe2 = _treeRegistry.GetByName(EnumItemType.Peaches);
        _peachInstance = new(recipe2);
        _cropRegistry = new();
        8.Times(() =>
        {
            CropInstances.Add(new CropInstance());
        });
        _animalRegistry = new();
        AnimalRecipe recipe3 = _animalRegistry.GetByName(EnumItemType.Milk);
        _cowInstance = new(recipe3);
        recipe3 = _animalRegistry.GetByName(EnumItemType.Eggs);
        _chickenInstance = new(recipe3);
        _buildingRecipe = new();
        _wind = new();
        _pastry = new();
    }
    public Func<Task>? StateChanged { get; set; }
    public int GetInventoryCount(EnumItemType item)
    {
        return _inventory.Get(item);
    }
    public BasicList<WorkerModel> GetAllWorkers => _workers.GetAllWorkers;
    //for now, not generic.  later be more generic.
    public void AddGrandmaWorker(WorkerModel worker)
    {
        worker.WorkerStatus = EnumWorkerStatus.Selected;
        _grandma.AddWorker(worker);
    }
    public void RemoveGrandmaWorker(WorkerModel worker)
    {
        worker.WorkerStatus = EnumWorkerStatus.None;
        _grandma.RemoveWorker(worker);
    }
    public bool CanGotoGrandmasGlade => _grandma.CanStartJob(_inventory);
    public void GotoGrandmasGlade()
    {
        _grandma.StartJob(_inventory);
        StateChanged?.Invoke();
    }
    public bool CanCollectRewardsFromGrandmasGlade => _grandma.CanCollectRewards;
    public BasicList<ItemAmount> GetRewardsFromGrandmasGlade() => _grandma.GetRewards();
    public void CollectAllGrandmaRewards(BasicList<ItemAmount> rewards)
    {
        foreach (var item in rewards)
        {
            _inventory.Add(item.Item, item.Amount);
        }
        _grandma.CollectAllRewards(); //i think.
        StateChanged?.Invoke();
        //since i will collect all the same time, hopefully no problem.
    }
    public BasicList<WorkerModel> GetGrandmasGladeWorkers => _grandma.Workers;
    public EnumWorksiteState GrandmasGladeStatus => _grandma.Status;
    public string GetGrandmasGladeDurationText => $"{_grandma.StartText} ({_grandma.Duration.GetTimeString})";
    public string GetGrandmasGladeProgressText => $"Come back in {_grandma.ReadyTime!.Value.GetTimeString}";
    public BasicList<WorksiteRewardPreview> GetGrandmasGladePreview() => _grandma.GetPreview();
    public BasicList<ItemAmount> GrandmasGladeSuppliesNeeded => _grandma.SuppliesNeeded;
    public void AddPondWorker(WorkerModel worker)
    {
        _pond.AddWorker(worker);
    }
    public void RemovePondWorker(WorkerModel worker)
    {
        _pond.RemoveWorker(worker);
    }
    public bool CanGotoPond => _pond.CanStartJob(_inventory);
    public void GotoPond()
    {
        _pond.StartJob(_inventory);
        StateChanged?.Invoke();
    }
    public bool CanCollectRewardsFromPond => _pond.CanCollectRewards;
    public BasicList<ItemAmount> GetRewardsFromPond() => _pond.GetRewards();
    public void CollectAllPondRewards(BasicList<ItemAmount> rewards)
    {
        foreach (var item in rewards)
        {
            _inventory.Add(item.Item, item.Amount);
        }
        _pond.CollectAllRewards(); //i think.
        StateChanged?.Invoke();
        //since i will collect all the same time, hopefully no problem.
    }
    public BasicList<WorkerModel> GetPondWorkers => _pond.Workers;
    public EnumWorksiteState PondStatus => _pond.Status;
    //this probably belongs somewhere else now too.
    public string GetPondDurationText => $"{_pond.StartText} ({_pond.Duration.GetTimeString})";
    public string GetPondProgressText => $"Come back in {_pond.ReadyTime!.Value.GetTimeString}";
    public BasicList<WorksiteRewardPreview> GetPondPreview() => _pond.GetPreview();
    public BasicList<ItemAmount> PondSuppliesNeeded => _pond.SuppliesNeeded;

    public int ApplesReady => _appleInstance.TreesReady;
    public string TimeLeftForApples => _appleInstance.ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetAppleState => _appleInstance.State;
    public void CollectApple()
    {
        _appleInstance.CollectTree();
        _inventory.Add(EnumItemType.Apples, 1);
        StateChanged?.Invoke();
    }
    public int PeachesReady => _peachInstance.TreesReady;
    public string TimeLeftForPeaches => _peachInstance.ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetPeachState => _peachInstance.State;
    public void CollectPeach()
    {
        _peachInstance.CollectTree();
        _inventory.Add(EnumItemType.Peaches, 1);
        StateChanged?.Invoke();
    }
    public bool CanPlant(CropInstance crop, EnumItemType item)
    {
        lock (Lock)
        {
            if (crop == null || crop.State != EnumCropState.Empty)
            {
                return false;
            }

            // Normal case: have at least 1 of the crop
            if (GetInventoryCount(item) > 0)
            {
                return true;
            }

            // Special rule: if player has 0 of a crop but none are currently growing,
            // allow planting one to avoid locking the game.
            // Special rule: allow planting one if nothing is growing
            var anyGrowing = CropInstances.Any(f => f.State == EnumCropState.Growing && f.Crop == item);
            return anyGrowing == false;
        }
    }
    public void Plant(CropInstance crop, EnumItemType item)
    {
        lock (Lock)
        {
            if (CanPlant(crop, item) == false)
            {
                throw new CustomBasicException("Cannot plant.  Should had called the CanPlant first");
            }

            if (GetInventoryCount(item) > 0)
            {
                _inventory.Consume(item, 1);
                StateChanged?.Invoke();
            }
            CropModel temp = _cropRegistry.GetByName(item);
            crop.Plant(item, temp.Duration);
            
            // Deduct crop only if available; do not go negative. If Wheat == 0
            // and CanPlant allowed due to no growing fields, permit the plant without deduction.
        }
    }
    private void AddInventory(EnumItemType item, int amount)
    {
        _inventory.Add(item, amount);
    }
    public void Harvest(CropInstance crop)
    {
        lock (Lock)
        {

            if (crop.Crop is null)
            {
                throw new CustomBasicException("No crop");
            }
            AddInventory(crop.Crop.Value, 2);
            StateChanged?.Invoke();
            crop.Clear();
        }
    }
    //this way the ui can tell what the possible crops are.
    //hint:  when i do abstractions, requires rethinking so databases can be later used.
    //public BasicList<EnumItemType> GetPossibleCrops =>
    //    [
    //        EnumItemType.Wheat,
    //        EnumItemType.Corn,
    //        EnumItemType.Honey,
    //        EnumItemType.Shrimp
    //    ];

    public int CornRequired(EnumQuantity quantity) => _chickenInstance.Required(quantity);
    public int EggsReturned(EnumQuantity quantity) => _chickenInstance.Returned(quantity);
    public bool CanProduceEggs(EnumQuantity quantity)
    {
        if (_chickenInstance.State != EnumAnimalState.None)
        {
            return false;
        }
        int required = _chickenInstance.Required(quantity);
        int cornInventory = _inventory.Get(EnumItemType.Corn);
        return cornInventory >= required;
    }
    public void ProduceEggs(EnumQuantity quantity)
    {
        if (CanProduceEggs(quantity) == false)
        {
            throw new CustomBasicException("Cannnot produce eggs.  Should had used CanProduceEggs function");
        }
        int required = _chickenInstance.Required(quantity);
        _inventory.Consume(EnumItemType.Corn, required);
        _chickenInstance.Produce(quantity);
        StateChanged?.Invoke();
    }
    public void CollectEggs()
    {
        if (_chickenInstance.OutputReady <= 0)
        {
            return;
        }
        _inventory.Add(EnumItemType.Eggs, 1);
        _chickenInstance.Collect();
        StateChanged?.Invoke();
    }
    public EnumAnimalState GetChickenState => _chickenInstance.State;
    public int EggsLeft => _chickenInstance.OutputReady;
    public string TimeLeftForChicken => _chickenInstance.ReadyTime!.Value.GetTimeString;
    public string ChickenDuration(EnumQuantity quantity) => _chickenInstance.GetDuration(quantity).GetTimeString;
    public int EggsInProgress => _chickenInstance.AmountInProgress;
    public int WheatRequired(EnumQuantity quantity) => _cowInstance.Required(quantity);
    public int MilkReturned(EnumQuantity quantity) => _cowInstance.Returned(quantity);
    public int MilkInProgress => _cowInstance.AmountInProgress;
    public bool CanProduceMilk(EnumQuantity quantity)
    {
        if (_cowInstance.State != EnumAnimalState.None)
        {
            return false;
        }
        int required = _cowInstance.Required(quantity);
        int wheatInventory = _inventory.Get(EnumItemType.Wheat);
        return wheatInventory >= required;
    }
    public void ProduceMilk(EnumQuantity quantity)
    {
        if (CanProduceMilk(quantity) == false)
        {
            throw new CustomBasicException("Cannot produce milk.  Should had used CanProduceMilk function");
        }
        int required = _cowInstance.Required(quantity);
        _inventory.Consume(EnumItemType.Wheat, required);
        _cowInstance.Produce(quantity);
        StateChanged?.Invoke();
    }
    //eventually cannot collect milk if you don't have enough inventory for it (later).
    public void CollectMilk()
    {
        if (_cowInstance.OutputReady <= 0)
        {
            return;
        }
        _inventory.Add(EnumItemType.Milk, 1);
        _cowInstance.Collect();
        StateChanged?.Invoke();
    }
    public EnumAnimalState GetCowState => _cowInstance.State;
    public int MilkLeft => _cowInstance.OutputReady;
    public string TimeLeftForCow => _cowInstance.ReadyTime!.Value.GetTimeString;
    public string CowDuration(EnumQuantity quantity) => _cowInstance.GetDuration(quantity).GetTimeString;
    public BuildingRecipeModel GetRecipe(EnumItemType item)
    {
        return _buildingRecipe.GetByName(item);
    }
    public bool HasPartialRequirement(EnumItemType item, int amountNeeded) => _inventory.Has(item, amountNeeded);
    public bool CanCraftFromWindmill(EnumItemType item)
    {
        lock (Lock)
        {
            BuildingRecipeModel recipe = _buildingRecipe.GetByName(item);
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
        BuildingRecipeModel recipe = _buildingRecipe.GetByName(item);
        _inventory.Consume(recipe.Inputs);
        StateChanged?.Invoke();
        CraftingJob job = new(recipe);
        _wind.Queue.Add(job);
    }

    public bool CanCraftFromPastryOven(EnumItemType item)
    {
        lock (Lock)
        {
            BuildingRecipeModel recipe = _buildingRecipe.GetByName(item);
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
        BuildingRecipeModel recipe = _buildingRecipe.GetByName(item);
        _inventory.Consume(recipe.Inputs);
        StateChanged?.Invoke();
        CraftingJob job = new(recipe);
        _pastry.Queue.Add(job);
    }
    void IGameTimer.Tick()
    {
        lock (Lock)
        {
            _grandma.UpdateTick();
            _pond.UpdateTick();
            _appleInstance.UpdateTick();
            _peachInstance.UpdateTick();
            foreach (var c in CropInstances)
            {
                c.UpdateTick();
            }
            _chickenInstance.UpdateTick();
            _cowInstance.UpdateTick();
            ProcessBuilding(_wind);
            ProcessBuilding(_pastry);
        }
    }
    private void ProcessBuilding(BuildingInstance building)
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