
namespace Phase17BeginningDataAbstractionsPart1.Data.Animals;
public class AnimalInstances(IAnimalRegistry recipes) : IAnimalInstances
{
    async Task<BasicList<string>> IAnimalInstances.GetAnimalInstancesAsync()
    {
        var list = await recipes.GetAnimalsAsync();
        return list.Select(x => x.Animal).ToBasicList();
    }
}