namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class TreesComponent(TreeManager manager)
{
    private BasicList<TreeSummary> _trees = [];
    protected override void OnInitialized()
    {
        base.OnInitialized();
        _trees = manager.GetAllTrees;
    }
    private string ReadyText(TreeSummary id) => $"Ready In {manager.TimeLeftForResult(id)}";
    private string ProduceText(TreeSummary id) => $"{manager.GetProduceAmount(id)} {manager.GetTreeName(id)}";
    private string GetName(TreeSummary id) => manager.GetTreeName(id);
    private void CollectResult(TreeSummary id)
    {
        manager.CollectSingleResult(id);
    }
}