namespace Phase08TestQuests.DataAccess.Animals;
public class AnimalFactory : IAnimalFactory
{
    AnimalServicesContext IAnimalFactory.GetAnimalServices(PlayerState player)
    {
        IAnimalCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new AnimalOneByOneCollectionPolicy();
        }
        else
        {
            collection = new AnimalAllAtOnceCollectionPolicy();
        }
        IAnimalRegistry register;
        register = new AnimalRecipeDatabase(player);
        AnimalInstanceDatabase instance = new(player);
        AnimalServicesContext output = new()
        {
            AnimalCollectionPolicy = collection,
            AnimalProgressionPolicy = new BasicAnimalPolicy(),
            AnimalRegistry = register,
            AnimalInstances = instance,
            AnimalPersistence = instance
        };
        return output;
    }
}