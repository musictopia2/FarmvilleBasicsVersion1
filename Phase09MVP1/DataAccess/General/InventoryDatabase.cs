namespace Phase09MVP1.DataAccess.General;
public class InventoryDatabase() : ListDataAccess<InventoryDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath), 
    ISqlDocumentConfiguration, IStartingInventoryProvider,
    IInventoryPersistence

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "Inventory";
    async Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync(FarmKey farm)
    {
        var list = await GetDocumentsAsync();
        return list.Single(x => x.Farm.Equals(farm)).List;
    }
    async Task IInventoryPersistence.SaveInventoryAsync(FarmKey farm, Dictionary<string, int> items)
    {
        var list = await GetDocumentsAsync();

        var current = list.Single(x => x.Farm.Equals(farm));
        current.List = items;
        await UpsertRecordsAsync(list);
    }
}