namespace Phase03ConcurrentPlayerSessions.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalDataModel>> GetAnimalInstancesAsync();
}