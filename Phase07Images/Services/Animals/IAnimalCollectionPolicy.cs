namespace Phase07Images.Services.Animals;
public interface IAnimalCollectionPolicy
{
    Task<EnumAnimalCollectionMode> GetCollectionModeAsync();
}