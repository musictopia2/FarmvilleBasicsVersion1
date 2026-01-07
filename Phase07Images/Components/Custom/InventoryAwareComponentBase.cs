namespace Phase07Images.Components.Custom;
public abstract class InventoryAwareComponentBase : FarmComponentBase, IDisposable
{
    protected override void OnInitialized()
    {
        Inventory.InventoryChanged += async () => await OnInventoryChangedAsync();
        base.OnInitialized();
    }
    protected virtual async Task OnInventoryChangedAsync()
    {
        await InvokeAsync(StateHasChanged);
    }
    public void Dispose()
    {
        Inventory?.InventoryChanged -= async () => await OnInventoryChangedAsync();
        GC.SuppressFinalize(this);
    }
}