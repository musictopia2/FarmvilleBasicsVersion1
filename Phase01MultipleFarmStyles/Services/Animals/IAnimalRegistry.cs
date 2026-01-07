namespace Phase01MultipleFarmStyles.Services.Animals;
public interface IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> GetAnimalsAsync();
}