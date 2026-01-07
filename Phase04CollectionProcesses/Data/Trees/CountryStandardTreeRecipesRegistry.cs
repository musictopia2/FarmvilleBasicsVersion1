namespace Phase04CollectionProcesses.Data.Trees;
public class CountryStandardTreeRecipesRegistry : ITreeRecipes
{
    Task<BasicList<TreeRecipe>> ITreeRecipes.GetTreesAsync()
    {
        BasicList<TreeRecipe> output = [];
        TreeRecipe tree = new()
        {
            TreeName = CountryTreeListClass.Apple,
            Item = CountryItemList.Apples,
            ProductionTimeForEach = TimeSpan.FromSeconds(10)
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = CountryTreeListClass.Peach,
            Item = CountryItemList.Peaches,
            ProductionTimeForEach = TimeSpan.FromHours(1)
        };
        output.Add(tree);
        return Task.FromResult(output);
    }
}