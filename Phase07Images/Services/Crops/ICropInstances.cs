namespace Phase07Images.Services.Crops;
public interface ICropInstances
{
    Task<CropSystemState> GetCropInstancesAsync();
}