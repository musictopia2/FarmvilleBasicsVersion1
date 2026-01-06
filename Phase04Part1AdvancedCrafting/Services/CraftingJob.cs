namespace Phase04Part1AdvancedCrafting.Services;
public class CraftingJob(RecipeModel recipe)
{
    public RecipeModel Recipe { get; } = recipe;
    public Guid Id { get; set; } = Guid.NewGuid();
    public EnumJobState State { get; private set; } = EnumJobState.Waiting;
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public bool IsComplete =>
        StartedAt != default &&
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
    public double ProgressSeconds
    {
        get
        {
            if (State != EnumJobState.Active)
            {
                return 0;
            }

            var elapsed = DateTime.Now - StartedAt;
            return Math.Min(Recipe.Duration.TotalSeconds, Math.Max(0, elapsed.TotalSeconds));
        }
    }

    public int ProgressPercent => (int)Math.Floor(ProgressSeconds / Recipe.Duration.TotalSeconds * 100);
    public int DurationSeconds => (int) Recipe.Duration.TotalSeconds;
}