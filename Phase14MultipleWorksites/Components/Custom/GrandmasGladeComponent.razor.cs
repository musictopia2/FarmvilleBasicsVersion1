namespace Phase14MultipleWorksites.Components.Custom;
public partial class GrandmasGladeComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    private BasicList<ItemAmount> _rewards = [];
    private BasicList<WorkerModel> _workers = [];
    private WorkerModel? _currentWorker;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => RunProcessAsync(), null, 0, 1000);
        _workers = state.GetAllWorkers;
        _currentWorker = _workers.First();
    }
    public EnumWorksiteState GrandmasGladeStatus => state.GrandmasGladeStatus; //later require rethinking.
    public BasicList<WorkerModel> GrandmasGladeWorkers => state.GetGrandmasGladeWorkers;
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
    private void RunProcessAsync()
    {
        if (state.GrandmasGladeStatus == EnumWorksiteState.Collecting && _rewards.Count == 0)
        {
            _rewards = state.GetRewardsFromGrandmasGlade();
        }
        if (state.GrandmasGladeStatus != EnumWorksiteState.Collecting)
        {
            _rewards.Clear();
        }
        InvokeAsync(StateHasChanged);
    }
    //if you cannot add worker, then disabled but can still view details about that worker.
    public bool CanAddWorker(WorkerModel worker) => worker.WorkerStatus == EnumWorkerStatus.None;
    public void CollectAllRewards()
    {
        state.CollectAllGrandmaRewards(_rewards);
        _workerIndex = 0; //back to 0.
    }
    public void AddWorker()
    {
        CustomBasicException.ThrowIfNull(_currentWorker);
        state.AddGrandmaWorker(_currentWorker);
    }
    public void RemoveWorker()
    {
        CustomBasicException.ThrowIfNull(_currentWorker);
        state.RemoveGrandmaWorker(_currentWorker);
    }
    public bool CanGoToGrandmasGlade => state.CanGotoGrandmasGlade;
    public void GoToGrandmasGlade()
    {
        state.GotoGrandmasGlade();
    }
    public string GetGrandmasGladeDurationText => state.GetGrandmasGladeDurationText;
    public string GetGrandmasGladeProgressText => state.GetGrandmasGladeProgressText;
    public BasicList<WorksiteRewardPreview> GetGrandmasGladePreview() => state.GetGrandmasGladePreview();
    private static string PreviewText(WorksiteRewardPreview preview) => $"{preview.Item.Words} ({preview.Amount})";
    public BasicList<ItemAmount> GrandmasGladeSuppliesNeeded => state.GrandmasGladeSuppliesNeeded;

    //for now, i do not have the full requirements like i did for multiple workshops.
    //that will come when i do multiple worksites.
    //hints:  if someone has enough, just shows something else.
    //i propose for my version, giving more details so a person has more warnings if they have too much of something.


}