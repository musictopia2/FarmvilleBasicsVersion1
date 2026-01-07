namespace Phase06Autoresume.Services.Animals;
public interface IAnimalFactory
{
    AnimalServicesContext GetAnimalServices(PlayerState player);
}