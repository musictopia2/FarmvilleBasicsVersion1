namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<AnimalDataModel>> GetAnimalInstancesAsync();
}