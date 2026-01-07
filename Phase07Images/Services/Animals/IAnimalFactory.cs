namespace Phase07Images.Services.Animals;
public interface IAnimalFactory
{
    AnimalServicesContext GetAnimalServices(PlayerState player);
}