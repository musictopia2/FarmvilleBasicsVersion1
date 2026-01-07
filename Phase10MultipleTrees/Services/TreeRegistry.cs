namespace Phase10MultipleTrees.Services;
public class TreeRegistry
{
    private readonly BasicList<TreeRecipe> _trees = [];
    public IReadOnlyList<TreeRecipe> All => _trees;
    public TreeRegistry()
    {
        LoadHardCodedTrees();
    }
    private void LoadHardCodedTrees()
    {

        TreeRecipe recipe = new()
        {
            Item = EnumItemType.Apples,
            ProductionTimeForEach = TimeSpan.FromSeconds(10)
        };
        _trees.Add(recipe);
        recipe = new()
        {
            Item = EnumItemType.Peaches,
            ProductionTimeForEach = TimeSpan.FromSeconds(30)
        };
        _trees.Add(recipe);

    }
    public TreeRecipe GetByName(EnumItemType item)
        => _trees.Single(r => r.Item == item);
}
