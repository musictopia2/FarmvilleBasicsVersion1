namespace Phase07Images.DataAccess.Workshops;
internal class WorkshopInstanceDatabase(PlayerState player) : ListDataAccess<WorkshopInstanceDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, IWorkshopInstances, IWorkshopPersistence

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "WorkshopInstances";
    async Task<BasicList<WorkshopAutoResumeModel>> IWorkshopInstances.GetWorkshopInstancesAsync()
    {
        var firsts = await GetDocumentsAsync();
        BasicList<WorkshopAutoResumeModel> output = firsts.Single(x => x.Player.Equals(player)).Workshops;
        return output;
    }
    async Task IWorkshopPersistence.SaveWorkshopsAsync(BasicList<WorkshopAutoResumeModel> workshops)
    {
        var list = await GetDocumentsAsync();
        var item = list.Single(x => x.Player.Equals(player));
        item.Workshops = workshops;
        await UpsertRecordsAsync(list);
    }
}