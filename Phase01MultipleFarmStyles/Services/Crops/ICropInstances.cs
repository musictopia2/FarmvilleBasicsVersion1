namespace Phase01MultipleFarmStyles.Services.Crops;
public interface ICropInstances
{
    Task<CropSystemState> GetCropInstancesAsync();
}