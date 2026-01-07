namespace Phase06Autoresume.Services.Crops;
public class CropInstance
{
    public Guid Id { get; } = Guid.NewGuid(); // unique per instance
    public bool Unlocked { get; set; }
    public EnumCropState State { get; private set; } = EnumCropState.Empty;
    public DateTime? PlantedAt { get; private set; }
    public string? Crop { get; private set; } = null;
    public TimeSpan? GrowTime { get; private set; } = null;
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
    public void Load(CropAutoResumeModel slot)
    {
        Crop = slot.Crop;
        State = slot.State;
        PlantedAt = slot.PlantedAt;
        Unlocked = slot.Unlocked;
        GrowTime = slot.GrowTime;
    }
    public void Plant(string crop, TimeSpan time)
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