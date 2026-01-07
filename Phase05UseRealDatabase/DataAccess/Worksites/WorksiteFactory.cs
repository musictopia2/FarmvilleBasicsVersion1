namespace Phase05UseRealDatabase.DataAccess.Worksites;
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
        IWorksiteRegistry register;
        register = new WorksiteRecipeDatabase(player);
        WorksiteServicesContext output = new()
        {
            WorksiteCollectionPolicy = collection,
            WorksiteProgressPolicy = new BasicWorksitePolicy(),
            WorksiteRegistry = register,
            WorksiteInstances = new BasicWorksiteInstances(register)
        };
        return output;
    }   
}