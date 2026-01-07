namespace Phase01MultipleFarmStyles.Data.Worksites;
public class WorksiteFactory : IWorksiteFactory
{
    WorksiteServicesContext IWorksiteFactory.GetWorksiteServices(string style)
    {
        if (style == FarmStyleList.Country)
        {
            return FromCountry();
        }
        if (style == FarmStyleList.Tropical)
        {
            return FromTropical();
        }
        throw new CustomBasicException("Not Supported");
    }
    private static WorksiteServicesContext FromCountry()
    {
        return new()
        {
            WorksiteRegistry = new CountryWorksitesRegistry(),
            WorksiteInstances = new CountryWorksiteInstances(),
            WorksitePolicy = new CountryWorksitePolicy(),
        };
    }
    private static WorksiteServicesContext FromTropical()
    {
        IWorksiteRegistry register = new TropicalWorksitesRegistry();
        return new()
        {
            WorksiteRegistry = new TropicalWorksitesRegistry(),
            WorksiteInstances = new TropicalWorksiteInstances(),
            WorksitePolicy = new TropicalWorksitePolicy(),
        };
    }

}