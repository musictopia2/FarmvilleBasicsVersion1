namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Animals;
public interface IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> GetAnimalsAsync();
}