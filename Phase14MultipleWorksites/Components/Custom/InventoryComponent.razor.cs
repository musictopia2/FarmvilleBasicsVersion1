namespace Phase14MultipleWorksites.Components.Custom;
public partial class InventoryComponent(GameState state)
{
    private BasicList<ItemAmount> _list = [];
    private void PopulateList()
    {
        _list = [];
        var firsts = EnumItemType.CompleteList;
        Console.Clear();
        foreach (var item in firsts)
        {
            int amount = state.GetInventoryCount(item);
            ItemAmount temp = new(item, amount);
            if (temp.Amount > 0)
            {
                _list.Add(temp);
            }
        }
    }
    private static string DisplayName(ItemAmount item) => $"{item.Item.Words}:";
    protected override void OnInitialized()
    {
        state.StateChanged = Refresh;
        PopulateList();
        base.OnInitialized();
    }
    private async Task Refresh()
    {
        PopulateList();
        await InvokeAsync(StateHasChanged);
    }
}