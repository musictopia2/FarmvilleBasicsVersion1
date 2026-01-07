namespace Phase03ConcurrentPlayerSessions.Services.Animals;
public interface IAnimalFactory
{
    AnimalServicesContext GetAnimalServices(PlayerState player);
}