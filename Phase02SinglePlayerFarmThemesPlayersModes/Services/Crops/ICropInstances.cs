namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Crops;
public interface ICropInstances
{
    Task<CropSystemState> GetCropInstancesAsync();
}