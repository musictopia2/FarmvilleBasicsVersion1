namespace Phase18SampleUpgrades.Services.Crops;
public class CropState
{
    public Guid Id { get; set; }
    public bool Unlocked { get; set; }
    public EnumCropState State { get; set; }
}