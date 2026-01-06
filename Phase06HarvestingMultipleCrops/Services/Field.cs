namespace Phase06HarvestingMultipleCrops.Services;
public class Field
{
    public EnumFieldState State { get; set; } = EnumFieldState.Empty;
    public DateTime? PlantedAt { get; set; }
    public EnumCropType? Crop { get; private set; } = null;
    public TimeSpan? GrowTime { get; set; } = null;
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumFieldState.Growing || PlantedAt is null)
            {
                return null;
            }
            var elapsed = DateTime.Now - PlantedAt.Value;
            var remaining = GrowTime - elapsed;
            return remaining > TimeSpan.Zero
                ? remaining
                : TimeSpan.Zero;
        }
    }
    public void Plant(EnumCropType crop, TimeSpan time)
    {
        State = EnumFieldState.Growing;
        GrowTime = time;
        Crop = crop;
        PlantedAt = DateTime.Now;
    }
    public void UpdateTick()
    {
        if (State != EnumFieldState.Growing || PlantedAt == null)
        {
            return;
        }

        var elapsed = DateTime.Now - PlantedAt.Value;
        if (elapsed >= GrowTime)
        {
            State = EnumFieldState.Ready;
            PlantedAt = null;
        }
    }
    public void Clear()
    {
        State = EnumFieldState.Empty;
        Crop = null;
        GrowTime = null;
        PlantedAt = null;
    }
}