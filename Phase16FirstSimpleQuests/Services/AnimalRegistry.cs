namespace Phase16FirstSimpleQuests.Services;
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
            Duration = TimeSpan.FromSeconds(5),
            Input = 3,
            Output = 1
        });
        options.Add(EnumQuantity.Double, new()
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 9,
            Output = 3
        });
        options.Add(EnumQuantity.Triple, new()
        {
            Duration = TimeSpan.FromMinutes(3),
            Input = 15,
            Output = 5
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
            Duration = TimeSpan.FromSeconds(10),
            Input = 2,
            Output = 2
        });
        options.Add(EnumQuantity.Double, new()
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 4,
            Output = 4
        });
        options.Add(EnumQuantity.Triple, new()
        {
            Duration = TimeSpan.FromMinutes(4),
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
