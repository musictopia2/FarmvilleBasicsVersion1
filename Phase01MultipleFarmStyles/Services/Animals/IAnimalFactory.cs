namespace Phase01MultipleFarmStyles.Services.Animals;
public interface IAnimalFactory
{
    AnimalServicesContext GetAnimalServices(string style);
}