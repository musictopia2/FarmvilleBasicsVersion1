namespace Phase08TestQuests.Services.Workshops;
public class CraftingJobInstance(WorkshopRecipe recipe)
{
    public WorkshopRecipe Recipe { get; } = recipe;
    public Guid Id { get; set; } = Guid.NewGuid();
    public EnumWorkshopState State { get; private set; } = EnumWorkshopState.Waiting;
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public bool IsComplete =>
        StartedAt is not null &&
        DateTime.Now - StartedAt >= Recipe.Duration;
    public void Start()
    {
        StartedAt = DateTime.Now;
        State = EnumWorkshopState.Active;
    }
    public void Load(CraftingAutoResumeModel craft)
    {
        State = craft.State;
        StartedAt = craft.StartedAt;
        CompletedAt = craft.CompletedAt;
    }
    public void Complete()
    {
        CompletedAt = DateTime.Now;
    }
    public void ReadyForManualPickup()
    {
        CompletedAt = DateTime.Now;
        State = EnumWorkshopState.ReadyToPickUpManually;
    }
    public void UpdateStartedAt(DateTime startedAt)
    {
        StartedAt = startedAt;
        State = EnumWorkshopState.Active;
    }
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumWorkshopState.Active || StartedAt is null)
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
    public CraftingAutoResumeModel GetCraftingForSaving
    {
        get
        {
            return new()
            {
                CompletedAt = CompletedAt,
                RecipeItem = Recipe.Item,
                StartedAt = StartedAt,
                State = State
            };
        }
    }
}