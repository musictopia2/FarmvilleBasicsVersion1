namespace Phase03ConcurrentPlayerSessions.Services.Crops;
public interface ICropInstances
{
    Task<CropSystemState> GetCropInstancesAsync();
}