namespace Phase03SimpleCrafting.Services;
public class Windmill(CraftingJob job)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public EnumJobState State { get; set; } = EnumJobState.Waiting;
    public CraftingJob Job { get; } = job;
    public double ProgressSeconds
    {
        get
        {
            if (State != EnumJobState.Active)
            {
                return 0;
            }
            var elapsed = DateTime.Now - Job.StartedAt;
            return Math.Min(Job.DurationSeconds, Math.Max(0, elapsed.TotalSeconds));
        }
    }
    public int ProgressPercent => (int)Math.Floor(ProgressSeconds / Job.DurationSeconds * 100);
    public void Start()
    {
        State = EnumJobState.Active;
        Job.StartedAt = DateTime.Now;
    }
    public void Complete()
    {
        State = EnumJobState.Completed;
        Job.CompletedAt = DateTime.Now;
    }
}