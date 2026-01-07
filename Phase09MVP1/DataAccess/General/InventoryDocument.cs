namespace Phase09MVP1.DataAccess.General;
public class InventoryDocument
{
    required public FarmKey Farm { get; set; }
    public Dictionary<string, int> List { get; set; } = [];
}