namespace Phase01MultipleFarmStyles.Data.Workshops;
public class WorkshopFactory : IWorkshopFactory
{
    WorkshopServicesContext IWorkshopFactory.GetWorkshopServices(string style)
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
    private static WorkshopServicesContext FromCountry()
    {
        IWorkshopRegistry register = new CountryWorkshopRecipesRegistry();
        return new()
        {
            WorkshopRegistry = register,
            WorkshopInstances = new CountryWorkshopInstances(register),
            WorkshopPolicy = new CountryWorkshopPolicy(),
        };
    }
    private static WorkshopServicesContext FromTropical()
    {
        IWorkshopRegistry register = new TropicalWorkshopRecipesRegistry();
        return new()
        {
            WorkshopRegistry = register,
            WorkshopInstances = new TropicalWorkshopInstances(register),
            WorkshopPolicy = new TropicalWorkshopPolicy(),
        };
    }
}