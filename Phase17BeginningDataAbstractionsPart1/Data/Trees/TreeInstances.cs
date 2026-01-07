namespace Phase17BeginningDataAbstractionsPart1.Data.Trees;
public class TreeInstances(ITreeRecipes recipes) : ITreeInstances
{
    async Task<BasicList<string>> ITreeInstances.GetTreeInstancesAsync()
    {
        var list = await recipes.GetTreesAsync();
        return list.Select(x => x.Item).ToBasicList();
    }
}