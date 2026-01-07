namespace Phase17BeginningDataAbstractionsPart1.Services.Animals;
public interface IAnimalInstances
{
    Task<BasicList<string>> GetAnimalInstancesAsync();
}
