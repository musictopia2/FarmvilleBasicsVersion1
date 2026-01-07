namespace Phase07Images.Components.Custom;
public partial class InventoryDisplayComponent(IToast toast) : InventoryAwareComponentBase
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
    private void DisplayInventoryItem(string itemName)
    {
        toast.ShowInfoToast(itemName.GetWords);
    }
    protected override async Task OnInventoryChangedAsync()
    {
        await base.OnInventoryChangedAsync();
        PopulateList();
    }
    // itemName is the image file name in wwwroot (root folder).
    // If itemName already includes an extension (e.g. "barn.png"), it will use it as-is.
    // If it doesn't, it assumes ".png".
    private static string GetItemImageSrc(string itemName)
    {
        return $"{itemName}.png";
    }
}