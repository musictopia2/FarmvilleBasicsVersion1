namespace Phase09MVP1.Services.Worksites;
public class WorksiteManualCollectionPolicy : IWorksiteCollectionPolicy
{
    Task<bool> IWorksiteCollectionPolicy.CollectAllAsync()
    {
        return Task.FromResult(false);
    }

}