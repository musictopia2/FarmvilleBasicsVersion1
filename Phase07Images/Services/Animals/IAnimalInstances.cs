namespace Phase07Images.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalAutoResumeModel>> GetAnimalInstancesAsync();
}