namespace Phase03ConcurrentPlayerSessions.Data.Workshops;
public class WorkshopFactory : IWorkshopFactory
{
    WorkshopServicesContext IWorkshopFactory.GetWorkshopServices(PlayerState player)
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return FromCountry(player);
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return FromTropical(player);
        }
        throw new CustomBasicException("Not Supported");
    }
    private static WorkshopServicesContext FromCountry(PlayerState player)
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
    private static WorkshopServicesContext FromTropical(PlayerState player)
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