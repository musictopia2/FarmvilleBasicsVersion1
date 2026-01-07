namespace Phase09SingleTrees.Services;
public class AppleClass
{
    public int ApplesReady { get; private set; } = GameState.TotalFromTrees; //to start with.
    public EnumTreeState State { get; private set; } = EnumTreeState.Collecting;
    private static TimeSpan ProductionTimePerApple => TimeSpan.FromSeconds(10);
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
            var totalTime = TimeSpan.FromTicks(ProductionTimePerApple.Ticks * GameState.TotalFromTrees);
            var remaining = totalTime - elapsed;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }
    }
    


    public bool CanCollectOneApple => ApplesReady > 0;

    private void StartCollecting()
    {
        if (State == EnumTreeState.Collecting && !IsCollecting)
        {
            IsCollecting = true;
            StartedAt = null; // pause timer
        }
    }

    public void CollectApple()
    {
        StartCollecting();

        if (ApplesReady <= 0)
        {
            return;
        }

        ApplesReady--;
        if (ApplesReady == 0)
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
        //var readyCount = (int)(elapsed.TotalSeconds / ProductionTimePerApple.TotalSeconds);

        var seconds = elapsed.TotalSeconds;
        var production = ProductionTimePerApple.TotalSeconds;
        if (seconds > production)
        {
            TempStart = DateTime.Now;
            ApplesReady++;
        }


        if (ApplesReady >= GameState.TotalFromTrees)
        {
            State = EnumTreeState.Collecting;
            ApplesReady = GameState.TotalFromTrees;
            StartedAt = null;
            TempStart = null;
        }
    }
}