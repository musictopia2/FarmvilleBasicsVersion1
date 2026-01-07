namespace Phase14MultipleWorksites.Services;
public class GameState : IGameTimer
{
    readonly Inventory _inventory;
    readonly WorksiteInstance _grandma;
    readonly WorksiteInstance _pond;
    readonly WorksiteRegistry _registry;
    readonly WorkerRegistry _workers;
    public GameState()
    {
        _inventory = new();
        _inventory.Add(EnumItemType.Biscuits, 5);
        _inventory.Add(EnumItemType.FarmersSoup, 2);
        _registry = new();
        _workers = new();
        WorksiteRecipe recipe = _registry.ForWorksite(EnumWorksiteLocation.GrandmasGlade);
        _grandma = new(recipe);
        recipe = _registry.ForWorksite(EnumWorksiteLocation.Pond);
        _pond = new(recipe);
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

    void IGameTimer.Tick()
    {
        _grandma.UpdateTick();
        _pond.UpdateTick();
    }
}