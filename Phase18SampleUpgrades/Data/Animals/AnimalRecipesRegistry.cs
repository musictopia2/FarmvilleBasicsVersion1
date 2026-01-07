namespace Phase18SampleUpgrades.Data.Animals;
public class AnimalRecipesRegistry : IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> IAnimalRegistry.GetAnimalsAsync()
    {
        BasicList<AnimalRecipe> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(5),
            Input = 1,
            Output = new(ItemList.Milk, 3),
            Required = ItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(30),
            Input = 3,
            Output = new(ItemList.Milk, 5),
            Required = ItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 5,
            Output = new(ItemList.Milk, 7),
            Required = ItemList.Wheat
        });
        AnimalRecipe recipe = new()
        {
            Animal = AnimalListClass.Cow,
            Options = options
        };
        output.Add(recipe);
        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(10),
            Input = 2,
            Output = new(ItemList.Eggs, 2),
            Required = ItemList.Corn
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(30),
            Input = 4,
            Output = new(ItemList.Eggs, 4),
            Required = ItemList.Corn
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(2),
            Input = 6,
            Output = new(ItemList.Eggs, 6),
            Required = ItemList.Corn
        });
         recipe = new()
        {
            Animal = AnimalListClass.Chicken,
            Options = options
        };
        output.Add(recipe);
        return Task.FromResult(output);
    }
}