namespace Phase05UseRealDatabase.DataAccess.Trees;
public class TreeInstanceDatabase(PlayerState player, ITreeRecipes recipes) : ListDataAccess<TreeInstanceDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, ITreeInstances

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "TreeInstances";
    public async Task ImportAsync(BasicList<TreeInstanceDocument> list)
    {
        await UpsertRecordsAsync(list);
    }

    async Task<BasicList<TreeDataModel>> ITreeInstances.GetTreeInstancesAsync()
    {
        var list = await recipes.GetTreesAsync();

        BasicList<TreeDataModel> output = [];

        var others = await GetDocumentsAsync();
        int maxs = others.Single(x => x.Player.Equals(player)).HowMany;
        foreach (var item in list)
        {
            maxs.Times(x =>
            {
                output.Add(new TreeDataModel()
                {
                    Name = item.TreeName,
                    Unlocked = true
                });
            });
        }
        return output;
    }
}