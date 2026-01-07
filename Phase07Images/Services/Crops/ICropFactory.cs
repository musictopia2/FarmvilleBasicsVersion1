namespace Phase07Images.Services.Crops;
public interface ICropFactory
{
    CropServicesContext GetCropServices(PlayerState player);
}