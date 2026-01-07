namespace Phase17BeginningDataAbstractionsPart1.Services.Trees;
public class TreeManager(Inventory inventory,
    ITreeRecipes treeRecipes,
    ITreeInstances treeInstances,
    ITreesCollecting treeCollecting
    )
{
    private readonly BasicList<TreeInstance> _trees = [];
    // Public read-only summaries for the UI
    public BasicList<TreeSummary> GetAllTrees
    {
        get
        {
            BasicList<TreeSummary> output = [];
            _trees.ForEach(t =>
            {
                TreeSummary summary = new()
                {
                    Id = t.Id,
                    Name = t.Name
                };
                output.Add(summary);
            });
            return output;
        }
    }
    // Private helper to find tree by Id
    public int GetProduceAmount(TreeSummary tree)
    {
        CustomBasicException.ThrowIfNull(tree); //still needs to pass since i may use in future.
        return treeCollecting.TreesCollectedAtTime; // for now
    }
    private TreeInstance GetTreeById(Guid id)
    {
        var tree = _trees.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Tree with Id {id} not found.");
        return tree;
    }
    private TreeInstance GetTreeById(TreeSummary id) => GetTreeById(id.Id);
    // Methods for UI to query dynamic state
    public int TreesReady(TreeSummary id) => GetTreeById(id).TreesReady;
    public string GetTreeName(TreeSummary id) => GetTreeById(id).Name;
    public string TimeLeftForResult(TreeSummary id) => GetTreeById(id).ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetTreeState(TreeSummary id) => GetTreeById(id).State;
    //this is when you collect only one item.
    public void CollectSingleResult(TreeSummary id)
    {
        TreeInstance instance = GetTreeById(id);
        instance.CollectTree();
        inventory.Add(instance.Name, 1);
    }
    // Populate from recipes + player instances
    public async Task PopulateTreesAsync()
    {
        BasicList<TreeRecipe> recipes = await treeRecipes.GetTreesAsync();
        var ours = await treeInstances.GetTreeInstancesAsync();
        foreach (var item in ours)
        {
            TreeRecipe recipe = recipes.Single(x => x.Item == item);
            TreeInstance tree = new(recipe, treeCollecting);
            _trees.Add(tree);
        }
    }
    // Tick method called by game timer
    public void UpdateTick()
    {
        _trees.ForEach(tree => tree.UpdateTick());
    }
}