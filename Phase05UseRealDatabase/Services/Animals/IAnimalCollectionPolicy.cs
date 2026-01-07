namespace Phase05UseRealDatabase.Services.Animals;
public interface IAnimalCollectionPolicy
{
    Task<EnumAnimalCollectionMode> GetCollectionModeAsync();
}