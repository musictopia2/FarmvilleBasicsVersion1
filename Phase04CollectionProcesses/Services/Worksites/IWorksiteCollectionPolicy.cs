namespace Phase04CollectionProcesses.Services.Worksites;
public interface IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> GetCollectionModeAsync();
}