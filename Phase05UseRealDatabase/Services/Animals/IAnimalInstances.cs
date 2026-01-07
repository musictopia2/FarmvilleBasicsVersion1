namespace Phase05UseRealDatabase.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalDataModel>> GetAnimalInstancesAsync();
}