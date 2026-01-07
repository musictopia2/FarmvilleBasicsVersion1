namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Worksites;
public class WorksiteFactory(PlayerState player) : IWorksiteFactory
{
    WorksiteServicesContext IWorksiteFactory.GetWorksiteServices()
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
    private WorksiteServicesContext FromCountry()
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
    private WorksiteServicesContext FromTropical()
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