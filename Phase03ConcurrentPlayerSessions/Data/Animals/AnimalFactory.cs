namespace Phase03ConcurrentPlayerSessions.Data.Animals;
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
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new CountryTestAnimalRecipesRegistry();
        }
        else
        {
            register = new CountryStandardAnimalRecipesRegistry();
        }
        return new()
        {
            AnimalRegistry = register,
            AnimalInstances = new BasicAnimalInstances(register),
            AnimalPolicy = new BasicAnimalPolicy(),
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
            AnimalPolicy = new BasicAnimalPolicy(),
        };
    }
}