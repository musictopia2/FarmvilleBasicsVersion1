namespace Phase09MVP1.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalAutoResumeModel>> GetAnimalInstancesAsync();
}