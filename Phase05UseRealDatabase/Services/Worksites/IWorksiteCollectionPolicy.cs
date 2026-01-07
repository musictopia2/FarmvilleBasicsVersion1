namespace Phase05UseRealDatabase.Services.Worksites;
public interface IWorksiteCollectionPolicy
{
    Task<EnumWorksiteCollectionMode> GetCollectionModeAsync();
}