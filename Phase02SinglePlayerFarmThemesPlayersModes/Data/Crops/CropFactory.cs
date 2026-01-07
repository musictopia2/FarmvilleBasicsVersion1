namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Crops;
public class CropFactory(PlayerState player) : ICropFactory
{
    CropServicesContext ICropFactory.GetCropServices()
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return GetCountryServices();
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return GetTropicalServices();
        }
        throw new CustomBasicException("Not supported");
    }
    private CropServicesContext GetCountryServices()
    {
        ICropRegistry register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new CountryTestCropRegistry();
        }
        else
        {
            register = new CountryStandardCropRegistry();
        }
        return new()
        {
            CropRegistry = register,
            CropInstances = new BasicCropInstances(register),
            CropPolicy = new BasicCropPolicy()
        };
    }
    private CropServicesContext GetTropicalServices()
    {
        ICropRegistry register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new TropicalTestCropRegistry();
        }
        else
        {
            register = new TropicalStandardCropRegistry();
        }
        return new()
        {
            CropRegistry = new TropicalTestCropRegistry(),
            CropInstances = new BasicCropInstances(register),
            CropPolicy = new BasicCropPolicy()
        };
    }
}