namespace Phase04CollectionProcesses.Data.Trees;
public class TropicalStandardTreeRecipesRegistry : ITreeRecipes
{
    Task<BasicList<TreeRecipe>> ITreeRecipes.GetTreesAsync()
    {
        BasicList<TreeRecipe> output = [];
        TreeRecipe tree = new()
        {
            TreeName = TropicalTreeListClass.Coconut,
            Item = TropicalItemList.Coconut,
            ProductionTimeForEach = TimeSpan.FromMinutes(2)
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = TropicalTreeListClass.Mango,
            Item = TropicalItemList.Mango,
            ProductionTimeForEach = TimeSpan.FromMinutes(15)
        };
        output.Add(tree);
        return Task.FromResult(output);
    }
}