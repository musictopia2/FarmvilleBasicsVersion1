namespace Phase01MultipleFarmStyles.Data.Animals;
public class TropicalAnimalInstances(IAnimalRegistry recipes) : IAnimalInstances
{
    async Task<BasicList<AnimalDataModel>> IAnimalInstances.GetAnimalInstancesAsync()
    {
        var list = await recipes.GetAnimalsAsync();
        BasicList<AnimalDataModel> output = [];
        foreach (var item in list)
        {
            //normally only 2 are allowed but doing 3 for testing.
            3.Times(x =>
            {
                bool unlocked;
                if (x > 1)
                {
                    unlocked = false;
                }
                else if (item.Animal == TropicalAnimalListClass.Chicken)
                {
                    unlocked = false;
                }
                else
                {
                    unlocked = true;
                }
                output.Add(new AnimalDataModel()
                {
                    Name = item.Animal,
                    Unlocked = unlocked,
                    UnlockedOptionCount = 1
                });
            });
        }
        return output;
    }
}