namespace Phase12MultipleHabitats.Services;
public class Habitat
{
    public EnumCropState State { get; set; } = EnumCropState.Empty;
    public DateTime? PlantedAt { get; set; }
    public EnumCropType? Crop { get; private set; } = null;
    public TimeSpan GrowTime { get; set; } = TimeSpan.FromMinutes(1); //take longer.  normally 45 minutes but take less time because of testing.
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumCropState.Growing || PlantedAt is null)
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
        State = EnumCropState.Growing;
        GrowTime = time;
        Crop = crop;
        PlantedAt = DateTime.Now;
    }
    public void UpdateTick()
    {
        if (State != EnumCropState.Growing || PlantedAt == null) return;
        var elapsed = DateTime.Now - PlantedAt.Value;
        if (elapsed >= GrowTime)
        {
            State = EnumCropState.Ready;
            PlantedAt = null;
        }
    }
    public void Clear()
    {
        State = EnumCropState.Empty;
        PlantedAt = null;
    }
}