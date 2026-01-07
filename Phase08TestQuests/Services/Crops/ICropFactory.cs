namespace Phase08TestQuests.Services.Crops;
public interface ICropFactory
{
    CropServicesContext GetCropServices(PlayerState player);
}