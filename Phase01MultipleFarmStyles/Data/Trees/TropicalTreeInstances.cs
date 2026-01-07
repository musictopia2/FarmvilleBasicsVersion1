namespace Phase01MultipleFarmStyles.Data.Trees;
public class TropicalTreeInstances(ITreeRecipes recipes) : ITreeInstances
{
    async Task<BasicList<TreeDataModel>> ITreeInstances.GetTreeInstancesAsync()
    {
        var list = await recipes.GetTreesAsync();
        BasicList<TreeDataModel> output = [];
        list.ForEach(x =>
        {
            3.Times(y =>
            {
                bool unLocked = false;
                if (x.TreeName == TropicalTreeListClass.Coconut)
                {
                    unLocked = true;
                }
                else
                {
                    unLocked = false;
                }
                if (y > 1)
                {
                    unLocked = false;
                }
                output.Add(new TreeDataModel()
                {
                    Name = x.TreeName,
                    Unlocked = unLocked
                });
            });
        });
        return output;
    }
}