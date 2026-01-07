namespace Phase06Autoresume.DataAccess.Worksites;
public class WorksiteFactory : IWorksiteFactory
{
    WorksiteServicesContext IWorksiteFactory.GetWorksiteServices(PlayerState player)
    {
        IWorksiteCollectionPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new WorksiteAutomatedCollectionPolicy();
        }
        else
        {
            collection = new WorksiteAllAtOnceCollectionPolicy();
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