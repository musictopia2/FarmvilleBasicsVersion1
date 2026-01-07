namespace Phase06Autoresume.Services.Crops;
public interface ICropFactory
{
    CropServicesContext GetCropServices(PlayerState player);
}