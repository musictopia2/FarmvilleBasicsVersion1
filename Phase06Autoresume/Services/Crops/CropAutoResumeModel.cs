namespace Phase06Autoresume.Services.Crops;
public class CropAutoResumeModel
{
    public string? Crop { get; set; }               // Crop planted (if any)
    public EnumCropState State { get; set; }       // Empty / Growing / Ready
    public DateTime? PlantedAt { get; set; } //when the crop was planted
    public bool Unlocked { get; set; } = true;             // Is this slot unlocked
    public TimeSpan? GrowTime { get; set; } = null;
}