namespace Phase17BeginningDataAbstractionsPart1.Data.Trees;
public class TreeRecipesRegistry : ITreeRecipes
{
    Task<BasicList<TreeRecipe>> ITreeRecipes.GetTreesAsync()
    {
        BasicList<TreeRecipe> output = [];
        TreeRecipe tree = new()
        {
            TreeName = TreeListClass.Apple,
            Item = ItemList.Apple,
            ProductionTimeForEach = TimeSpan.FromSeconds(5)
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = TreeListClass.Peach,
            Item = ItemList.Peach,
            ProductionTimeForEach = TimeSpan.FromSeconds(10)
        };
        output.Add(tree);
        return Task.FromResult(output);
    }
}