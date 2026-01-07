namespace Phase08TestQuests.Services.Animals;
public interface IAnimalFactory
{
    AnimalServicesContext GetAnimalServices(PlayerState player);
}