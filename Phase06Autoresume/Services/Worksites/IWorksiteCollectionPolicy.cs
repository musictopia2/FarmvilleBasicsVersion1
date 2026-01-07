namespace Phase06Autoresume.Services.Worksites;
public interface IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> GetCollectionModeAsync();
}