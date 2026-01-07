
namespace Phase06Autoresume.Services.Worksites;
public class WorksiteAutomatedCollectionPolicy : IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> IWorksiteCollectionPolicy.GetCollectionModeAsync()
    {
        return Task.FromResult(EnumWorksiteCollectionMode.Automated);
    }
}