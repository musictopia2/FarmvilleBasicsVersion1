
namespace Phase04CollectionProcesses.Components.Custom;
public partial class TreesComponent
{
    private BasicList<TreeView> _trees = [];
    protected override void OnInitialized()
    {

        Refresh();

        base.OnInitialized();

    }
    protected override Task OnTickAsync()
    {
        Refresh();
        return base.OnTickAsync();
    }
    private void Refresh()
    {
        _trees = TreeManager.GetUnlockedTrees;
    }
    //for collecting, can't just say one (since you may do all at once if possible).
    //future, a person may be able to set whether they want to do one by one or all.
    private string ReadyText(TreeView id) => $"Ready In {TreeManager.TimeLeftForResult(id)}";
    private string ProduceText(TreeView id) => $"{TreeManager.GetProduceAmount(id)} {TreeManager.GetTreeName(id)}";
    private string GetName(TreeView id) => TreeManager.GetTreeName(id);
    private async Task CollectResultAsync(TreeView id)
    {
        await TreeManager.CollectFromTreeAsync(id);
    }
}