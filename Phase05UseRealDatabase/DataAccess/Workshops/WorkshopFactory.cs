namespace Phase05UseRealDatabase.DataAccess.Workshops;
public class WorkshopFactory : IWorkshopFactory
{
    WorkshopServicesContext IWorkshopFactory.GetWorkshopServices(PlayerState player)
    {
        IWorkshopCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new WorkshopAutomatedCollectionPolicy();
        }
        else
        {
            collection = new WorkshopManualCollectionPolicy();
        }
        IWorkshopRegistry register;
        register = new WorkshopRecipeDatabase(player);
        WorkshopServicesContext output = new()
        {
            WorkshopCollectionPolicy = collection,
            WorkshopProgressionPolicy = new BasicWorkshopPolicy(),
            WorkshopRegistry = register,
            WorkshopInstances = new WorkshopInstanceDatabase(player, register)
        };
        return output;
    }   
}