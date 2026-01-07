namespace Phase07Images.DataAccess.General;
public class InventoryDocument
{
    required public PlayerState Player { get; set; }
    public Dictionary<string, int> List { get; set; } = [];
}