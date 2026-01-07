namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Animals;
public class AnimalServicesContext
{
    required
    public IAnimalRegistry AnimalRegistry { get; init; }
    required
    public IAnimalInstances AnimalInstances { get; init; }
    required
    public IAnimalPolicy AnimalPolicy { get; init; }
}