namespace Phase03SimpleCrafting.Services;
public class CraftingJob(EnumJobType type)
{
    public EnumJobType Type { get; } = type;
    public int DurationSeconds { get; } = type switch
    {
        EnumJobType.Flour => 30,
        EnumJobType.Sugar => 120,
        _ => 0
    };

    public TimeSpan CraftTime => TimeSpan.FromSeconds(DurationSeconds);

    public DateTime StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }


}
