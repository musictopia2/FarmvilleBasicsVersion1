namespace Phase01MultipleFarmStyles.Services.Crops;
public interface ICropFactory
{
    CropServicesContext GetCropServices(string style);
}