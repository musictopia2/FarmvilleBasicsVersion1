namespace Phase04CollectionProcesses.Data.Animals;
public class AnimalFactory : IAnimalFactory
{
    AnimalServicesContext IAnimalFactory.GetAnimalServices(PlayerState player)
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
    private static AnimalServicesContext FromCountry(PlayerState player)
    {
        IAnimalRegistry register;
        IAnimalCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new CountryTestAnimalRecipesRegistry();
            collection = new AnimalOneByOneCollectionPolicy();
        }
        else
        {
            register = new CountryStandardAnimalRecipesRegistry();
            collection = new AnimalOneByOneCollectionPolicy();
        }
        return new()
        {
            AnimalRegistry = register,
            AnimalInstances = new BasicAnimalInstances(register),
            AnimalProgressionPolicy = new BasicAnimalPolicy(),
            AnimalCollectionPolicy = collection
        };
    }
    private static AnimalServicesContext FromTropical(PlayerState player)
    {
        IAnimalRegistry register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new TropicalTestAnimalRecipesRegistry();
        }
        else
        {
            register = new TropicalStandardAnimalRecipesRegistry();
        }
        return new()
        {
            AnimalRegistry = register,
            AnimalInstances = new BasicAnimalInstances(register),
            AnimalProgressionPolicy = new BasicAnimalPolicy(),
            AnimalCollectionPolicy = new AnimalAutomatedCollectionPolicy()
        };
    }
}