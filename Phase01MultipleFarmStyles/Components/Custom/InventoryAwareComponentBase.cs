namespace Phase01MultipleFarmStyles.Components.Custom;
public abstract class InventoryAwareComponentBase : ComponentBase, IDisposable
{
    protected abstract Inventory Inventory { get; }
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