namespace Phase08MultipleAnimals.Services;
public class AnimalRegistry
{
    private readonly BasicList<AnimalRecipe> _animals = [];
    public IReadOnlyList<AnimalRecipe> All => _animals;
    public AnimalRegistry()
    {
        LoadHardCodedAnimals();
    }
    private void LoadHardCodedAnimals()
    {
        Dictionary<EnumQuantity, AnimalProductionOption> options = [];
        options.Add(EnumQuantity.Single, new()
        {
            Duration = TimeSpan.FromSeconds(30),
            Input = 3,
            Output = 1
        });
        options.Add(EnumQuantity.Double, new()
        {
            Duration = TimeSpan.FromMinutes(2),
            Input = 6,
            Output = 2
        });
        options.Add(EnumQuantity.Triple, new()
        {
            Duration = TimeSpan.FromMinutes(6),
            Input = 9,
            Output = 3
        });

        AnimalRecipe recipe = new(options)
        {
            Animal = EnumAnimalType.Cow,
            Output = EnumItemType.Milk,
            Required = EnumItemType.Wheat
        };
        _animals.Add(recipe);
        options = [];
        options.Add(EnumQuantity.Single, new()
        {
            Duration = TimeSpan.FromMinutes(2),
            Input = 2,
            Output = 2
        });
        options.Add(EnumQuantity.Double, new()
        {
            Duration = TimeSpan.FromMinutes(20),
            Input = 4,
            Output = 4
        });
        options.Add(EnumQuantity.Triple, new()
        {
            Duration = TimeSpan.FromHours(1),
            Input = 6,
            Output = 6
        });
        recipe = new(options)
        {
            Animal = EnumAnimalType.Chicken,
            Output = EnumItemType.Eggs,
            Required = EnumItemType.Corn
        };
        _animals.Add(recipe);
    }
    public AnimalRecipe GetByName(EnumItemType item)
        => _animals.Single(r => r.Output == item);
}
