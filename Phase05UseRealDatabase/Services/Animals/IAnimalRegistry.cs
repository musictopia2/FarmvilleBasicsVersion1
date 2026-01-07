namespace Phase05UseRealDatabase.Services.Animals;
public interface IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> GetAnimalsAsync();
}