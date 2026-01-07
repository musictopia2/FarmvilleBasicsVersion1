
namespace Phase06Autoresume.Components.Custom;
public partial class WorksiteComponent
{

    [Parameter]
    [EditorRequired]
    public string Location { get; set; }
    private BasicList<ItemAmount> _rewards = [];
    private BasicList<WorkerRecipe> _workers = [];
    private WorkerRecipe? _currentWorker;

    private EnumWorksiteCollectionMode _mode;
    protected override void OnInitialized()
    {
        _workers = WorksiteManager.GetUnlockedWorkers;
        _currentWorker = _workers.First();
        base.OnInitialized();
    }
    protected override async Task OnParametersSetAsync()
    {
        _mode = await WorksiteManager.GetCollectionModeAsync();
        await base.OnParametersSetAsync();
    }
    public EnumWorksiteState Status => WorksiteManager.GetStatus(Location);
    public BasicList<WorkerRecipe> Workers => WorksiteManager.GetWorkers(Location);
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
        if (WorksiteManager.GetStatus(Location) == EnumWorksiteState.Collecting && _rewards.Count == 0)
        {
            _rewards = WorksiteManager.GetRewards(Location);
            WorksiteManager.StoreRewards(Location, _rewards);
        }
        if (WorksiteManager.GetStatus(Location) != EnumWorksiteState.Collecting)
        {
            _rewards.Clear();
        }
    }
    //if you cannot add worker, then disabled but can still view details about that worker.
    private static bool CanAddWorker(WorkerRecipe worker) => worker.WorkerStatus == EnumWorkerStatus.None;
    private void CollectAllRewards()
    {
        WorksiteManager.CollectAllRewards(Location, _rewards);
        _workerIndex = 0; //back to 0.
    }
    private void CollectSingleReward()
    {

        //if (_rewards.Count == 1)
        //{
        //    CollectAllRewards(); //because only one left.
        //    return;
        //}

        WorksiteManager.CollectSingleReward(Location);
        //_rewards.RemoveFirstItem(); //otherwise, i get error.
        //_rewards = WorksiteManager.GetRewards(Location);
    }


    private void AddWorker()
    {
        CustomBasicException.ThrowIfNull(_currentWorker);
        WorksiteManager.AddWorker(Location, _currentWorker);
    }
    private void RemoveWorker()
    {
        CustomBasicException.ThrowIfNull(_currentWorker);
        WorksiteManager.RemoveWorker(Location, _currentWorker);
    }
    private bool CanStartJob => WorksiteManager.CanStartJob(Location);
    private void StartJob()
    {
        WorksiteManager.StartJob(Location);
    }
    private string GetDurationText => WorksiteManager.GetDurationText(Location);
    private string GetProgressText => WorksiteManager.GetProgressText(Location);
    private BasicList<WorksiteRewardPreview> GetPreview() => WorksiteManager.GetPreview(Location);
    private static string PreviewText(WorksiteRewardPreview preview) => $"{preview.Item} ({preview.Amount})";
    private BasicList<ItemAmount> SuppliesNeeded => WorksiteManager.SuppliesNeeded(Location);
}