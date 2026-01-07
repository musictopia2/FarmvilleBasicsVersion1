namespace Phase05UseRealDatabase.DataAccess.Animals;
public class AnimalFactory : IAnimalFactory
{
    AnimalServicesContext IAnimalFactory.GetAnimalServices(PlayerState player)
    {
        IAnimalCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new AnimalAutomatedCollectionPolicy();
        }
        else
        {
            collection = new AnimalAllAtOnceCollectionPolicy();
        }
        IAnimalRegistry register;
        register = new AnimalRecipeDatabase(player);
        AnimalServicesContext output = new()
            {
                AnimalCollectionPolicy = collection,
                AnimalProgressionPolicy = new BasicAnimalPolicy(),
                AnimalRegistry  = register,
                AnimalInstances  = new AnimalInstanceDatabase(player, register)
            };
        return output;
    }
}