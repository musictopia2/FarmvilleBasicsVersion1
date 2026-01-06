namespace Phase02;
internal class CraftingJob(EnumJobType type)
{
    public EnumJobType Type { get; } = type;
    public int DurationSeconds { get; } = type switch
    {
        EnumJobType.Flour => 30,
        EnumJobType.Sugar => 120,
        _ => 0
    };

    public override string ToString()
        => $"{Type} ({DurationSeconds}s)";
}
