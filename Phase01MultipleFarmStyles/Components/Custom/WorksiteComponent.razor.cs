
namespace Phase01MultipleFarmStyles.Components.Custom;
public partial class WorksiteComponent(WorksiteManager manager)
{

    [Parameter]
    [EditorRequired]
    public string Location { get; set; }
    private BasicList<ItemAmount> _rewards = [];
    private BasicList<WorkerRecipe> _workers = [];
    private WorkerRecipe? _currentWorker;
    protected override void OnInitialized()
    {
        _workers = manager.GetUnlockedWorkers;
        _currentWorker = _workers.First();
        base.OnInitialized();
    }
    public EnumWorksiteState Status => manager.GetStatus(Location);
    public BasicList<WorkerRecipe> Workers => manager.GetWorkers(Location);
    private int _workerIndex = 0;
    public bool CanGoUp => _workerIndex > 0;
    public bool CanGoDown => _workerIndex < _workers.Count - 1;
    public void GoUp()
    {
        _workerIndex--;
        _currentWorker = _workers[_workerIndex];
    }
    public void GoDown()
    {
        _workerIndex++;
        _currentWorker = _workers[_workerIndex];
    }
    protected override Task OnTickAsync()
    {
        RunProcess();
        return base.OnTickAsync();
    }
    private void RunProcess()
    {
        if (manager.GetStatus(Location) == EnumWorksiteState.Collecting && _rewards.Count == 0)
        {
            _rewards = manager.GetRewards(Location);
        }
        if (manager.GetStatus(Location) != EnumWorksiteState.Collecting)
        {
            _rewards.Clear();
        }
    }
    //if you cannot add worker, then disabled but can still view details about that worker.
    public bool CanAddWorker(WorkerRecipe worker) => worker.WorkerStatus == EnumWorkerStatus.None;
    public void CollectAllRewards()
    {
        manager.CollectAllRewards(Location, _rewards);
        _workerIndex = 0; //back to 0.
    }
    public void AddWorker()
    {
        CustomBasicException.ThrowIfNull(_currentWorker);
        manager.AddWorker(Location, _currentWorker);
    }
    public void RemoveWorker()
    {
        CustomBasicException.ThrowIfNull(_currentWorker);
        manager.RemoveWorker(Location, _currentWorker);
    }
    public bool CanStartJob => manager.CanStartJob(Location);
    public void StartJob()
    {
        manager.StartJob(Location);
    }
    public string GetDurationText => manager.GetDurationText(Location);
    public string GetProgressText => manager.GetProgressText(Location);
    public BasicList<WorksiteRewardPreview> GetPreview() => manager.GetPreview(Location);
    private static string PreviewText(WorksiteRewardPreview preview) => $"{preview.Item} ({preview.Amount})";
    public BasicList<ItemAmount> SuppliesNeeded => manager.SuppliesNeeded(Location);
}