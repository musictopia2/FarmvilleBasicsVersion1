namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Animals;
public class AnimalFactory(PlayerState player) : IAnimalFactory
{
    AnimalServicesContext IAnimalFactory.GetAnimalServices()
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
    private AnimalServicesContext FromCountry()
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
    private AnimalServicesContext FromTropical()
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