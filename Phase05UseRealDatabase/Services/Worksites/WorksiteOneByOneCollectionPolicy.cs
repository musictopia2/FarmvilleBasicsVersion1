namespace Phase05UseRealDatabase.Services.Worksites;
public class WorksiteOneByOneCollectionPolicy : IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> IWorksiteCollectionPolicy.GetCollectionModeAsync()
    {
        return Task.FromResult(EnumWorksiteCollectionMode.OneAtTime);
    }
}