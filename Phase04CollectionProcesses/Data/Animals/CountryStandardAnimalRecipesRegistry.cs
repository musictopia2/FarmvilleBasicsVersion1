namespace Phase04CollectionProcesses.Data.Animals;
public class CountryStandardAnimalRecipesRegistry : IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> IAnimalRegistry.GetAnimalsAsync()
    {
        BasicList<AnimalRecipe> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 1,
            Output = new(CountryItemList.Milk, 1),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(20),
            Input = 3,
            Output = new(CountryItemList.Milk, 3),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(1),
            Input = 5,
            Output = new(CountryItemList.Milk, 5),
            Required = CountryItemList.Wheat
        });
        AnimalRecipe recipe = new()
        {
            Animal = CountryAnimalListClass.Cow,
            Options = options
        };
        output.Add(recipe);
        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(4),
            Input = 2,
            Output = new(CountryItemList.Eggs, 2),
            Required = CountryItemList.Corn
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(1),
            Input = 4,
            Output = new(CountryItemList.Eggs, 4),
            Required = CountryItemList.Corn
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(3),
            Input = 6,
            Output = new(CountryItemList.Eggs, 6),
            Required = CountryItemList.Corn
        });
        recipe = new()
        {
            Animal = CountryAnimalListClass.Chicken,
            Options = options
        };
        output.Add(recipe);
        return Task.FromResult(output);
    }
}