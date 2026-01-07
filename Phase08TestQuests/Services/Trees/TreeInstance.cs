namespace Phase08TestQuests.Services.Trees;
public class TreeInstance(TreeRecipe tree, ITreesCollecting collecting)
{
    public Guid Id { get; } = Guid.NewGuid(); // unique per instance
    public bool Unlocked { get; set; }
    public string Name => tree.Item;
    public string TreeName => tree.TreeName;
    public int TreesReady { get; private set; } = collecting.TreesCollectedAtTime; //to start with.
    public EnumTreeState State { get; private set; } = EnumTreeState.Collecting;
    private TimeSpan ProductionTimePerTree => tree.ProductionTimeForEach;
    private DateTime? StartedAt { get; set; } // production start time
    private DateTime? TempStart { get; set; }
    private bool IsCollecting { get; set; } = false;
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumTreeState.Producing || StartedAt is null)
            {
                return null;
            }

            var elapsed = DateTime.Now - StartedAt.Value;
            var totalTime = TimeSpan.FromTicks(ProductionTimePerTree.Ticks * collecting.TreesCollectedAtTime);
            var remaining = totalTime - elapsed;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }
    }
    public bool CanCollectOneTree => TreesReady > 0;
    private void StartCollecting()
    {
        if (State == EnumTreeState.Collecting && !IsCollecting)
        {
            IsCollecting = true;
            StartedAt = null; // pause timer
        }
    }
    public TreeAutoResumeModel GetTreeForSaving
    {
        get
        {
            return new()
            {
                StartedAt = StartedAt,
                TempStart = TempStart,
                State = State,
                TreeName = TreeName,
                TreesReady = TreesReady,
                Unlocked = Unlocked
            };
        }
    }
    public void Load(TreeAutoResumeModel tree)
    {
        State = tree.State;
        TempStart = tree.TempStart;
        Unlocked = tree.Unlocked;
        TreesReady = tree.TreesReady;
        StartedAt = tree.StartedAt;
    }
    public void CollectTree()
    {
        StartCollecting();

        if (TreesReady <= 0)
        {
            return;
        }

        TreesReady--;
        if (TreesReady == 0)
        {
            // reset production for next batch
            State = EnumTreeState.Producing;
            IsCollecting = false;
            StartedAt = DateTime.Now;
            TempStart = DateTime.Now;
        }
    }
    private bool _needsSaving;
    public bool NeedsToSave => _needsSaving;

    public void UpdateTick()
    {
        _needsSaving = false;

        if (State != EnumTreeState.Producing || TempStart is null)
        {
            return;
        }

        var elapsed = DateTime.Now - TempStart.Value;
        var productionSeconds = ProductionTimePerTree.TotalSeconds;

        // How many full trees should have been produced
        int produced = (int)(elapsed.TotalSeconds / productionSeconds);

        if (produced > 0)
        {
            TreesReady += produced;
            _needsSaving = true;

            if (TreesReady >= collecting.TreesCollectedAtTime)
            {
                TreesReady = collecting.TreesCollectedAtTime;
                State = EnumTreeState.Collecting;
                StartedAt = null;
                TempStart = null;
            }
            else
            {
                // Advance TempStart by the amount of time used for produced trees
                TempStart = TempStart.Value.AddSeconds(produced * productionSeconds);
            }
        }
    }
}