namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Workshops;
public class WorkshopFactory(PlayerState player) : IWorkshopFactory
{
    WorkshopServicesContext IWorkshopFactory.GetWorkshopServices()
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return FromCountry();
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return FromTropical();
        }
        throw new CustomBasicException("Not Supported");
    }
    private WorkshopServicesContext FromCountry()
    {
        IWorkshopRegistry register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new CountryTestWorkshopRecipesRegistry();
        }
        else
        {
            register = new CountryStandardWorkshopRecipesRegistry();
        }
        return new()
        {
            WorkshopRegistry = register,
            WorkshopInstances = new BasicWorkshopInstances(register),
            WorkshopPolicy = new BasicWorkshopPolicy(),
        };
    }
    private WorkshopServicesContext FromTropical()
    {
        IWorkshopRegistry register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new TropicalTestWorkshopRecipesRegistry();
        }
        else
        {
            register = new TropicalStandardWorkshopRecipesRegistry();
        }
        return new()
        {
            WorkshopRegistry = register,
            WorkshopInstances = new BasicWorkshopInstances(register),
            WorkshopPolicy = new BasicWorkshopPolicy(),
        };
    }
}