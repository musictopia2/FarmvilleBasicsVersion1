namespace Phase15CombineBasicMechanics.Services;
public class CropInstance
{
    public EnumCropState State { get; set; } = EnumCropState.Empty;
    public DateTime? PlantedAt { get; set; }
    //cannot do recipes ahead of time for crops.
    public EnumItemType? Crop { get; private set; } = null;
    public TimeSpan? GrowTime { get; set; } = null;
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
    public void Plant(EnumItemType crop, TimeSpan time)
    {
        State = EnumCropState.Growing;
        GrowTime = time;
        Crop = crop;
        PlantedAt = DateTime.Now;
    }
    public void UpdateTick()
    {
        if (State != EnumCropState.Growing || PlantedAt == null)
        {
            return;
        }

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
        Crop = null;
        GrowTime = null;
        PlantedAt = null;
    }
}