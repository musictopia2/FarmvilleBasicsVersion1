namespace Phase03ConcurrentPlayerSessions.Data.Trees;
public class BasicTreeInstances(ITreeRecipes recipes) : ITreeInstances
{
    async Task<BasicList<TreeDataModel>> ITreeInstances.GetTreeInstancesAsync()
    {
        var list = await recipes.GetTreesAsync();
        BasicList<TreeDataModel> output = [];
        list.ForEach(x =>
        {
            1.Times(y =>
            {
                output.Add(new TreeDataModel()
                {
                    Name = x.TreeName,
                    Unlocked = true
                });
            });
        });
        return output;
    }
}