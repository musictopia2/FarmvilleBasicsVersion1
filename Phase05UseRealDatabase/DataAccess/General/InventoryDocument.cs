namespace Phase05UseRealDatabase.DataAccess.General;
public class InventoryDocument
{
    required public PlayerState Player { get; set; }
    public Dictionary<string, int> List { get; set; } = [];
}