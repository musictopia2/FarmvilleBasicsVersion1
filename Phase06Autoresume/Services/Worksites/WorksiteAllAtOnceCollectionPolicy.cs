namespace Phase06Autoresume.Services.Worksites;
public class WorksiteAllAtOnceCollectionPolicy : IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> IWorksiteCollectionPolicy.GetCollectionModeAsync()
    {
        return Task.FromResult(EnumWorksiteCollectionMode.AllAtOnce); //a person still has to do but get all instead of doing one by one
    }
}