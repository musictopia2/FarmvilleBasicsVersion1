namespace Phase01MultipleFarmStyles.Data.Trees;
public class TropicalTreeRecipesRegistry : ITreeRecipes
{
    Task<BasicList<TreeRecipe>> ITreeRecipes.GetTreesAsync()
    {
        BasicList<TreeRecipe> output = [];
        TreeRecipe tree = new()
        {
            TreeName = TropicalTreeListClass.Coconut,
            Item = TropicalItemList.Coconuts,
            ProductionTimeForEach = TimeSpan.FromSeconds(6)
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = TropicalTreeListClass.Mango,
            Item = TropicalItemList.Coconuts,
            ProductionTimeForEach = TimeSpan.FromSeconds(12)
        };
        output.Add(tree);
        return Task.FromResult(output);
    }
}