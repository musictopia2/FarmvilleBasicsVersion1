namespace Phase07Images.DataAccess.Worksites;
public class WorksiteFactory : IWorksiteFactory
{
    WorksiteServicesContext IWorksiteFactory.GetWorksiteServices(PlayerState player)
    {
        IWorksiteCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new WorksiteManualCollectionPolicy(); //needs to try one by one to see how to make it easy to pick up my rewards.

        }
        else
        {
            collection = new WorksiteManualCollectionPolicy();
        }
        WorksiteInstanceDatabase instance = new(player);

        IWorksiteRegistry register;
        register = new WorksiteRecipeDatabase(player);
        WorksiteServicesContext output = new()
        {
            WorksiteCollectionPolicy = collection,
            WorksiteProgressPolicy = new BasicWorksitePolicy(),
            WorksiteRegistry = register,
            WorksiteInstances = instance,
            WorksitePersistence  = instance
        };
        return output;
    }   
}