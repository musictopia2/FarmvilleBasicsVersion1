namespace Phase04Part1AdvancedCrafting.Services;
public class RecipeRegistry
{
    private readonly BasicList<RecipeModel> _recipes = [];
    public IReadOnlyList<RecipeModel> All => _recipes;
    public RecipeRegistry()
    {
        LoadHardCodedRecipes();
    }
    private void LoadHardCodedRecipes()
    {
        _recipes.Add(new RecipeModel
        {
            Item = EnumItemType.Flour,
            Building = EnumBuildingCategory.Windmill,
            Inputs = { [EnumItemType.Wheat] = 3 },
            Output = new ItemAmount(EnumItemType.Flour, 1),
            Duration = TimeSpan.FromSeconds(30)
        });

        _recipes.Add(new RecipeModel
        {
            Item = EnumItemType.Sugar,
            Building = EnumBuildingCategory.Windmill,
            Inputs = { [EnumItemType.Corn] = 2 },
            Output = new ItemAmount(EnumItemType.Sugar, 1),
            Duration = TimeSpan.FromSeconds(120)
        });

        _recipes.Add(new RecipeModel
        {
            Item = EnumItemType.Biscuits,
            Building = EnumBuildingCategory.PastryOven,
            Inputs =
            {
                [EnumItemType.Flour] = 1,
                [EnumItemType.Milk] = 1
            },
            Output = new ItemAmount(EnumItemType.Biscuits, 1),
            Duration = TimeSpan.FromSeconds(30)
        });

        _recipes.Add(new RecipeModel
        {
            Item = EnumItemType.ApplePie,
            Building = EnumBuildingCategory.PastryOven,
            Inputs =
            {
                [EnumItemType.Flour] = 2,
                [EnumItemType.Apples] = 4,
                [EnumItemType.Milk] = 1
            },
            Output = new ItemAmount(EnumItemType.ApplePie, 1),
            Duration = TimeSpan.FromSeconds(60)
        });
    }
    public IEnumerable<RecipeModel> ForBuilding(EnumBuildingCategory building)
        => _recipes.Where(r => r.Building == building);
    public RecipeModel GetByName(EnumItemType item)
        => _recipes.Single(r => r.Item == item);
}