
namespace Phase18SampleUpgrades.Components.Custom;
public partial class TreesComponent(TreeManager manager)
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
        _trees = manager.GetUnlockedTrees;
    }
    private string ReadyText(TreeView id) => $"Ready In {manager.TimeLeftForResult(id)}";
    private string ProduceText(TreeView id) => $"{manager.GetProduceAmount(id)} {manager.GetTreeName(id)}";
    private string GetName(TreeView id) => manager.GetTreeName(id);
    private void CollectResult(TreeView id)
    {
        manager.CollectSingleResult(id);
    }
}