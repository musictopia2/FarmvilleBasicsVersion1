namespace Phase09MVP1.Services.Crops;
public interface ICropInstances
{
    Task<CropSystemState> GetCropInstancesAsync();
}