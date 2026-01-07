namespace Phase09MVP1.Services.Crops;
public class CropAutomatedHarvestPolicy : ICropHarvestPolicy
{
    Task<bool> ICropHarvestPolicy.IsAutomaticAsync()
    {
        return Task.FromResult(true);
    }
}