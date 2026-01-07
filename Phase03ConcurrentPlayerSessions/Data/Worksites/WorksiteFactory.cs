namespace Phase03ConcurrentPlayerSessions.Data.Worksites;
public class WorksiteFactory : IWorksiteFactory
{
    WorksiteServicesContext IWorksiteFactory.GetWorksiteServices(PlayerState player)
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
    private static WorksiteServicesContext FromCountry(PlayerState player)
    {
        IWorksiteRegistry registry;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            registry = new CountryTestWorksitesRegistry();
        }
        else
        {
            registry = new CountryStandardWorksitesRegistry();
        }
        return new()
        {
            WorksiteRegistry = registry,
            WorksiteInstances = new BasicWorksiteInstances(registry),
            WorksitePolicy = new BasicWorksitePolicy(),
        };
    }
    private static WorksiteServicesContext FromTropical(PlayerState player)
    {
        IWorksiteRegistry register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new TropicalTestWorksitesRegistry();
        }
        else
        {
            register = new TropicalStandardWorksitesRegistry();
        }
        return new()
        {
            WorksiteRegistry = register,
            WorksiteInstances = new BasicWorksiteInstances(register),
            WorksitePolicy = new BasicWorksitePolicy(),
        };
    }
}