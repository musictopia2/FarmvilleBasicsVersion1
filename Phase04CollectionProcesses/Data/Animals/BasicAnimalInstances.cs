namespace Phase04CollectionProcesses.Data.Animals;
public class BasicAnimalInstances(IAnimalRegistry recipes) : IAnimalInstances
{
    async Task<BasicList<AnimalDataModel>> IAnimalInstances.GetAnimalInstancesAsync()
    {
        var list = await recipes.GetAnimalsAsync();
        BasicList<AnimalDataModel> output = [];
        foreach (var item in list)
        {
            1.Times(x =>
            {
                output.Add(new AnimalDataModel()
                {
                    Name = item.Animal,
                    Unlocked = true,
                    UnlockedOptionCount = item.Options.Count
                });
            });
        }
        return output;
    }
}