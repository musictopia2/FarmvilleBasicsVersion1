namespace Phase03ConcurrentPlayerSessions.Data.Animals;
public class TropicalStandardAnimalRecipesRegistry : IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> IAnimalRegistry.GetAnimalsAsync()
    {
        BasicList<AnimalRecipe> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 1,
            Output = new(TropicalItemList.Fish, 2),
            Required = TropicalItemList.Pineapple
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(20),
            Input = 3,
            Output = new(TropicalItemList.Fish, 4),
            Required = TropicalItemList.Pineapple
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(1),
            Input = 3,
            Output = new(TropicalItemList.Fish, 6),
            Required = TropicalItemList.Pineapple
        });
        AnimalRecipe recipe = new()
        {
            Animal = TropicalAnimalListClass.Dolphin,
            Options = options
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(2),
            Input = 2,
            Output = new(TropicalItemList.Eggs, 1),
            Required = TropicalItemList.Rice
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(30),
            Input = 6,
            Output = new(TropicalItemList.Eggs, 3),
            Required = TropicalItemList.Rice
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(2),
            Input = 10,
            Output = new(TropicalItemList.Eggs, 5),
            Required = TropicalItemList.Rice
        });
        recipe = new()
        {
            Animal = TropicalAnimalListClass.Chicken,
            Options = options
        };
        output.Add(recipe);
        return Task.FromResult(output);
    }
}