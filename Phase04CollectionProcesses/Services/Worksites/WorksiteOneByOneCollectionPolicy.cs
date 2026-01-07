namespace Phase04CollectionProcesses.Services.Worksites;
public class WorksiteOneByOneCollectionPolicy : IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> IWorksiteCollectionPolicy.GetCollectionModeAsync()
    {
        return Task.FromResult(EnumWorksiteCollectionMode.OneAtTime);
    }
}