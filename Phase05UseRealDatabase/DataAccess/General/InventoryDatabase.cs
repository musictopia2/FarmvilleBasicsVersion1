namespace Phase05UseRealDatabase.DataAccess.General;
public class InventoryDatabase() : ListDataAccess<InventoryDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath), 
    ISqlDocumentConfiguration, IStartingInventoryProvider

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "Inventory";
    async Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync(PlayerState player)
    {
        var list = await GetDocumentsAsync();
        return list.Single(x => x.Player.Equals(player)).List;
    }
}