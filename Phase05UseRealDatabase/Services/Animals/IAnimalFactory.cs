namespace Phase05UseRealDatabase.Services.Animals;
public interface IAnimalFactory
{
    AnimalServicesContext GetAnimalServices(PlayerState player);
}