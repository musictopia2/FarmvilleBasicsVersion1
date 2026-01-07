namespace Phase01MultipleFarmStyles.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalDataModel>> GetAnimalInstancesAsync();
}