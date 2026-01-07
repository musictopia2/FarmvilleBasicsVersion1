namespace Phase03ConcurrentPlayerSessions.Services.Crops;
public interface ICropFactory
{
    CropServicesContext GetCropServices(PlayerState player);
}