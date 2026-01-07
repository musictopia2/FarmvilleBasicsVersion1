namespace Phase07Images.DataAccess.General;
public class InventoryDatabase() : ListDataAccess<InventoryDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath), 
    ISqlDocumentConfiguration, IStartingInventoryProvider,
    IInventoryPersistence

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "Inventory";
    async Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync(PlayerState player)
    {
        var list = await GetDocumentsAsync();
        return list.Single(x => x.Player.Equals(player)).List;
    }
    async Task IInventoryPersistence.SaveInventoryAsync(PlayerState player, Dictionary<string, int> items)
    {
        var list = await GetDocumentsAsync();

        var current = list.Single(x => x.Player.Equals(player));
        current.List = items;
        await UpsertRecordsAsync(list);
    }
}