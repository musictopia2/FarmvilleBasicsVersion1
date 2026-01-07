namespace Phase16FirstSimpleQuests.Services;
public class TreeInstance(TreeRecipe recipe)
{
    public int TreesReady { get; private set; } = GameState.TotalFromTrees; //to start with.
    public EnumTreeState State { get; private set; } = EnumTreeState.Collecting;
    private TimeSpan ProductionTimePerTree => recipe.ProductionTimeForEach;
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
            var totalTime = TimeSpan.FromTicks(ProductionTimePerTree.Ticks * GameState.TotalFromTrees);
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
    public void UpdateTick()
    {
        if (State != EnumTreeState.Producing || TempStart is null)
        {
            return;
        }
        var elapsed = DateTime.Now - TempStart.Value;
        var seconds = elapsed.TotalSeconds;
        var production = ProductionTimePerTree.TotalSeconds;
        if (seconds > production)
        {
            TempStart = DateTime.Now;
            TreesReady++;
        }
        if (TreesReady >= GameState.TotalFromTrees)
        {
            State = EnumTreeState.Collecting;
            TreesReady = GameState.TotalFromTrees;
            StartedAt = null;
            TempStart = null;
        }
    }
}