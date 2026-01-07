namespace Phase01MultipleFarmStyles.Data.Animals;
public class AnimalFactory : IAnimalFactory
{
    AnimalServicesContext IAnimalFactory.GetAnimalServices(string style)
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
    private static AnimalServicesContext FromCountry()
    {
        IAnimalRegistry register = new CountryAnimalRecipesRegistry();
        return new()
        {
            AnimalRegistry = register,
            AnimalInstances = new CountryAnimalInstances(register),
            AnimalPolicy = new CountryAnimalPolicy(),
        };
    }
    private static AnimalServicesContext FromTropical()
    {
        IAnimalRegistry register = new TropicalAnimalRecipesRegistry();
        return new()
        {
            AnimalRegistry = register,
            AnimalInstances = new TropicalAnimalInstances(register),
            AnimalPolicy = new TropicalAnimalPolicy(),
        };
    }
}