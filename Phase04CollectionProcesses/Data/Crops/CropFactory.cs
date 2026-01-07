namespace Phase04CollectionProcesses.Data.Crops;
public class CropFactory : ICropFactory
{
    CropServicesContext ICropFactory.GetCropServices(PlayerState player)
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return GetCountryServices(player);
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return GetTropicalServices(player);
        }
        throw new CustomBasicException("Not supported");
    }
    private static CropServicesContext GetCountryServices(PlayerState player)
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
            CropProgressionPolicy = new BasicCropPolicy(),
            CropHarvestPolicy = new CropManualHarvestPolicy() //for now so i can test when doing it manually.
        };
    }
    private static CropServicesContext GetTropicalServices(PlayerState player)
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
            CropProgressionPolicy = new BasicCropPolicy(),
            CropHarvestPolicy = new CropAutomatedHarvestPolicy()
        };
    }
}