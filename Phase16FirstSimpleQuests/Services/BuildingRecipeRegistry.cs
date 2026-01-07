namespace Phase16FirstSimpleQuests.Services;
public class BuildingRecipeRegistry
{
    private readonly BasicList<BuildingRecipeModel> _recipes = [];
    public IReadOnlyList<BuildingRecipeModel> All => _recipes;
    public BuildingRecipeRegistry()
    {
        LoadHardCodedRecipes();
    }
    private void LoadHardCodedRecipes()
    {
        _recipes.Add(new BuildingRecipeModel
        {
            Item = EnumItemType.Flour,
            Building = EnumBuildingCategory.Windmill,
            Inputs = { [EnumItemType.Wheat] = 3 },
            Output = new ItemAmount(EnumItemType.Flour, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        _recipes.Add(new BuildingRecipeModel
        {
            Item = EnumItemType.Sugar,
            Building = EnumBuildingCategory.Windmill,
            Inputs = { [EnumItemType.Corn] = 2 },
            Output = new ItemAmount(EnumItemType.Sugar, 1),
            Duration = TimeSpan.FromSeconds(20)
        });

        _recipes.Add(new BuildingRecipeModel
        {
            Item = EnumItemType.Biscuits,
            Building = EnumBuildingCategory.PastryOven,
            Inputs =
            {
                [EnumItemType.Flour] = 1,
                [EnumItemType.Milk] = 1
            },
            Output = new ItemAmount(EnumItemType.Biscuits, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        _recipes.Add(new BuildingRecipeModel
        {
            Item = EnumItemType.ApplePies,
            Building = EnumBuildingCategory.PastryOven,
            Inputs =
            {
                [EnumItemType.Flour] = 2,
                [EnumItemType.Apples] = 4,
                [EnumItemType.Milk] = 1
            },
            Output = new ItemAmount(EnumItemType.ApplePies, 1),
            Duration = TimeSpan.FromSeconds(20)
        });
    }
    public IEnumerable<BuildingRecipeModel> ForBuilding(EnumBuildingCategory building)
        => _recipes.Where(r => r.Building == building);
    public BuildingRecipeModel GetByName(EnumItemType item)
        => _recipes.Single(r => r.Item == item);
}