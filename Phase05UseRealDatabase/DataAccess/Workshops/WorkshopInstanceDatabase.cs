namespace Phase05UseRealDatabase.DataAccess.Workshops;
internal class WorkshopInstanceDatabase(PlayerState player, IWorkshopRegistry recipes) : ListDataAccess<WorkshopInstanceDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, IWorkshopInstances

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "WorkshopInstances";
    async Task<BasicList<WorkshopDataModel>> IWorkshopInstances.GetWorkshopInstancesAsync()
    {
        var list = await recipes.GetWorkshopRecipesAsync();
        var nexts = list.GroupBy(x => x.BuildingName);
        BasicList<WorkshopDataModel> output = [];
        var others = await GetDocumentsAsync();
        int maxs = others.Single(x => x.Player.Equals(player)).HowMany;
        foreach (var item in nexts)
        {
            maxs.Times(x =>
            {
                output.Add(new WorkshopDataModel()
                {
                    Name = item.Key,
                    Capcity = 5,
                    Unlocked = true
                });
            });
        }
        
        return output;
    }
}