namespace Phase13SingleWorksites.Services;
public class GameState : IGameTimer
{
    readonly Inventory _inventory;
    readonly GrandmasGladeJob _grandma;
    public GameState()
    {
        _inventory = new();
        _inventory.Add(EnumItemType.Biscuits, 2); //you will receive 2 of them.  so you can only go to grandmas glade twice total. 
        _grandma = new();
    }
    public Func<Task>? StateChanged { get; set; }
    public int GetInventoryCount(EnumItemType item)
    {
        return _inventory.Get(item);
    }
    //for now, not generic.  later be more generic.
    public void AddWorker(WorkerModel worker)
    {
        worker.WorkerStatus = EnumWorkerStatus.Selected;
        _grandma.AddWorker(worker);
    }
    public void RemoveWorker(WorkerModel worker)
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
    public void CollectAllRewards(BasicList<ItemAmount> rewards)
    {
        foreach (var item in rewards)
        {
            _inventory.Add(item.Item, item.Amount);
        }
        _grandma.CollectAllRewards(); //i think.
        StateChanged?.Invoke();
        //since i will collect all the same time, hopefully no problem.
    }
    public BasicList<WorkerModel> GetAllWorkers => WorkerDefinition.Workers;
    public BasicList<WorkerModel> GetGrandmasGladeWorkers => _grandma.Workers;
    public EnumWorksiteState GrandmasGladeStatus => _grandma.Status;
    public string GetGrandmasGladeDurationText => $"Go Foraging! ({_grandma.Duration.GetTimeString})";
    public string GetGrandmasGladeProgressText => $"Come back in {_grandma.ReadyTime!.Value.GetTimeString}";
    public BasicList<WorksiteRewardPreview> GetGrandmasGladePreview() => _grandma.GetPreview();
    public BasicList<ItemAmount> GrandmasGladeSuppliesNeeded => _grandma.SuppliesNeeded;
    void IGameTimer.Tick()
    {
        _grandma.UpdateTick();
    }
}