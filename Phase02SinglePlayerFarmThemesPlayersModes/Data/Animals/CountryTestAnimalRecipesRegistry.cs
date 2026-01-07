namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Animals;
public class CountryTestAnimalRecipesRegistry : IAnimalRegistry
{
    Task<BasicList<AnimalRecipe>> IAnimalRegistry.GetAnimalsAsync()
    {
        BasicList<AnimalRecipe> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(5),
            Input = 1,
            Output = new(CountryItemList.Milk, 3),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(30),
            Input = 3,
            Output = new(CountryItemList.Milk, 5),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 5,
            Output = new(CountryItemList.Milk, 7),
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
            Duration = TimeSpan.FromSeconds(10),
            Input = 2,
            Output = new(CountryItemList.Eggs, 2),
            Required = CountryItemList.Corn
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(30),
            Input = 4,
            Output = new(CountryItemList.Eggs, 4),
            Required = CountryItemList.Corn
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(2),
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