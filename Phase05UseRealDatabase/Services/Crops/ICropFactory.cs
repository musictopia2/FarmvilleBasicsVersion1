namespace Phase05UseRealDatabase.Services.Crops;
public interface ICropFactory
{
    CropServicesContext GetCropServices(PlayerState player);
}