namespace Phase03ConcurrentPlayerSessions.Services.Crops;
public class CropSlotState
{
    public Guid Id { get; set; }
    public bool Unlocked { get; set; }
    public EnumCropState State { get; set; }
}