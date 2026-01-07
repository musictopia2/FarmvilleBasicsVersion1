namespace Phase18SampleUpgrades.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalDataModel>> GetAnimalInstancesAsync();
}