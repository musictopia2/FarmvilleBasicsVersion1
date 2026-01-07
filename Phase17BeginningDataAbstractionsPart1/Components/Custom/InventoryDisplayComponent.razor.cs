namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class InventoryDisplayComponent(Inventory inventory) : InventoryAwareComponentBase
{
    override protected Inventory Inventory => inventory;
    private BasicList<ItemAmount> _list = [];
    protected override void OnInitialized()
    {
        PopulateList();
        base.OnInitialized();
    }
    private void PopulateList()
    {
        _list = inventory.GetAllInventoryItems();
    }
    protected override async Task OnInventoryChangedAsync()
    {
        await base.OnInventoryChangedAsync();
        PopulateList();
    }
}