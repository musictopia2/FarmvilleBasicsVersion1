
namespace Phase03ConcurrentPlayerSessions.Components.Custom;
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
    private string ReadyText(TreeView id) => $"Ready In {TreeManager.TimeLeftForResult(id)}";
    private string ProduceText(TreeView id) => $"{TreeManager.GetProduceAmount(id)} {TreeManager.GetTreeName(id)}";
    private string GetName(TreeView id) => TreeManager.GetTreeName(id);
    private void CollectResult(TreeView id)
    {
        TreeManager.CollectSingleResult(id);
    }
}