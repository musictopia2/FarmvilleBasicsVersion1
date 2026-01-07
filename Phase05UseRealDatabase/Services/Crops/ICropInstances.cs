namespace Phase05UseRealDatabase.Services.Crops;
public interface ICropInstances
{
    Task<CropSystemState> GetCropInstancesAsync();
}