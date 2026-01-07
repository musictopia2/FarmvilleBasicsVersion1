namespace Phase08TestQuests.DataAccess.Workshops;
public class WorkshopFactory : IWorkshopFactory
{
    WorkshopServicesContext IWorkshopFactory.GetWorkshopServices(PlayerState player)
    {
        IWorkshopCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new WorkshopManualCollectionPolicy();
        }
        else
        {
            collection = new WorkshopManualCollectionPolicy();
        }
        IWorkshopRegistry register;
        register = new WorkshopRecipeDatabase(player);
        WorkshopInstanceDatabase instance = new(player);
        WorkshopServicesContext output = new()
        {
            WorkshopCollectionPolicy = collection,
            WorkshopProgressionPolicy = new BasicWorkshopPolicy(),
            WorkshopRegistry = register,
            WorkshopInstances = instance,
            WorkshopPersistence = instance
        };
        return output;
    }   
}