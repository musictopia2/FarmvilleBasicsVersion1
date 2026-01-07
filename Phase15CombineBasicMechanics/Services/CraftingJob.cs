namespace Phase15CombineBasicMechanics.Services;
public class CraftingJob(BuildingRecipeModel recipe)
{
    public BuildingRecipeModel Recipe { get; } = recipe;
    public Guid Id { get; set; } = Guid.NewGuid();
    public EnumJobState State { get; private set; } = EnumJobState.Waiting;
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public bool IsComplete =>
        StartedAt is not null &&
        DateTime.Now - StartedAt >= Recipe.Duration;
    public void Start()
    {
        StartedAt = DateTime.Now;
        State = EnumJobState.Active;
    }
    public void Complete()
    {
        CompletedAt = DateTime.Now;
        State = EnumJobState.Completed;
    }
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumJobState.Active || StartedAt is null)
            {
                return null;
            }
            var elapsed = DateTime.Now - StartedAt.Value;
            var remaining = Recipe.Duration - elapsed;
            return remaining > TimeSpan.Zero
                ? remaining
                : TimeSpan.Zero;
        }
    }


    //public double ProgressSeconds
    //{
    //    get
    //    {
    //        if (State != EnumJobState.Active)
    //        {
    //            return 0;
    //        }

    //        var elapsed = DateTime.Now - StartedAt;
    //        return Math.Min(Recipe.Duration.TotalSeconds, Math.Max(0, elapsed.TotalSeconds));
    //    }
    //}

    //public int ProgressPercent => (int)Math.Floor(ProgressSeconds / Recipe.Duration.TotalSeconds * 100);
    //public int DurationSeconds => (int) Recipe.Duration.TotalSeconds;
}