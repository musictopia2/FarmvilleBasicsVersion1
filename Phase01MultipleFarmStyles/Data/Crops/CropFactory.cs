namespace Phase01MultipleFarmStyles.Data.Crops;
public class CropFactory : ICropFactory
{
    CropServicesContext ICropFactory.GetCropServices(string style)
    {
        if (style == FarmStyleList.Country)
        {
            return GetCountryServices();
        }
        if (style == FarmStyleList.Tropical)
        {
            return GetTropicalServices();
        }
        throw new CustomBasicException("Not supported");
    }
    private static CropServicesContext GetCountryServices()
    {
        ICropRegistry register = new CountryCropRegistry();
        return new()
        {
            CropRegistry = register,
            CropInstances = new CountryCropInstances(register),
            CropPolicy = new CountryCropPolicy(),
        };
    }
    private static CropServicesContext GetTropicalServices()
    {
        ICropRegistry register = new TropicalCropRegistry();
        return new()
        {
            CropRegistry = new TropicalCropRegistry(),
            CropInstances = new TropicalCropInstances(register),
            CropPolicy = new TropicalCropPolicy(),
        };
    }
}