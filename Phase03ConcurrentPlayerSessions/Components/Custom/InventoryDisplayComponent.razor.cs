namespace Phase03ConcurrentPlayerSessions.Components.Custom;
public partial class InventoryDisplayComponent : InventoryAwareComponentBase
{
    private BasicList<ItemAmount> _list = [];
    protected override void OnInitialized()
    {
        PopulateList();
        base.OnInitialized();
    }
    private void PopulateList()
    {
        _list = Inventory.GetAllInventoryItems();
    }
    protected override async Task OnInventoryChangedAsync()
    {
        PopulateList();
        await base.OnInventoryChangedAsync();
    }
}