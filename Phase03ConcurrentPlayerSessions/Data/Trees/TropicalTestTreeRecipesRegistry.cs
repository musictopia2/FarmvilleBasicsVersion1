namespace Phase03ConcurrentPlayerSessions.Data.Trees;
public class TropicalTestTreeRecipesRegistry : ITreeRecipes
{
    Task<BasicList<TreeRecipe>> ITreeRecipes.GetTreesAsync()
    {
        BasicList<TreeRecipe> output = [];
        TreeRecipe tree = new()
        {
            TreeName = TropicalTreeListClass.Coconut,
            Item = TropicalItemList.Coconut,
            ProductionTimeForEach = TimeSpan.FromSeconds(6)
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = TropicalTreeListClass.Mango,
            Item = TropicalItemList.Coconut,
            ProductionTimeForEach = TimeSpan.FromSeconds(12)
        };
        output.Add(tree);
        return Task.FromResult(output);
    }
}