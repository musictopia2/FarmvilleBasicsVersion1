namespace Phase18SampleUpgrades.Services.Trees;

public class TreeManager(Inventory inventory,
    ITreeRecipes treeRecipes,
    ITreeInstances treeInstances,
    ITreesCollecting treeCollecting,
    ITreePolicy treePolicy
    )
{
    private readonly BasicList<TreeInstance> _trees = [];
    public event Action? OnTreesUpdated;
    // Public read-only summaries for the UI
    public BasicList<TreeView> GetUnlockedTrees
    {
        get
        {
            BasicList<TreeView> output = [];
            _trees.ForConditionalItems(x => x.Unlocked, t =>
            {
                TreeView summary = new()
                {
                    Id = t.Id,
                    Name = t.Name //this may be okay (?)
                };
                output.Add(summary);
            });
            return output;
        }
    }
    private BasicList<TreeState> GetAllTrees
    {
        get
        {
            BasicList<TreeState> output = [];
            _trees.ForEach(t =>
            {
                TreeState tree = new()
                {
                    Id = t.Id,
                    Name = t.TreeName,
                    State = t.State,
                    Unlocked = t.Unlocked
                };
                output.Add(tree);
            });
            return output;
        }
    }
    // Private helper to find tree by Id
    public int GetProduceAmount(TreeView tree)
    {
        CustomBasicException.ThrowIfNull(tree); //still needs to pass since i may use in future.
        return treeCollecting.TreesCollectedAtTime; // for now
    }
    private TreeInstance GetTreeById(Guid id)
    {
        var tree = _trees.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Tree with Id {id} not found.");
        return tree;
    }
    private TreeInstance GetTreeById(TreeView id) => GetTreeById(id.Id);

    public async Task<bool> CanUnlockTreeAsync(string name)
    {
        var list = GetAllTrees;
        var policy = await treePolicy.CanUnlockTreeAsync(list, name);
        return policy;
    }

    public async Task UnlockTreeAsync(string name)
    {
        var list = GetAllTrees;
        var policy = await treePolicy.UnlockTreeAsync(list, name);
        UpdateTreeInstance(policy);
    }

    public async Task<bool> CanLockTreeAsync(string name)
    {
        var list = GetAllTrees;
        var policy = await treePolicy.CanLockTreeAsync(list, name);
        return policy;
    }

    public async Task LockTreeAsync(string name)
    {
        var list = GetAllTrees;
        var policy = await treePolicy.LockTreeAsync(list, name);
        UpdateTreeInstance(policy);
    }

    private void UpdateTreeInstance(TreeState summary)
    {
        var tree = GetTreeById(summary);
        tree.Unlocked = summary.Unlocked;
        OnTreesUpdated?.Invoke();
    }



    // Methods for UI to query dynamic state
    public int TreesReady(TreeView id) => GetTreeById(id).TreesReady;
    public string GetTreeName(TreeView id) => GetTreeById(id).Name;
    public string TimeLeftForResult(TreeView id) => GetTreeById(id).ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetTreeState(TreeView id) => GetTreeById(id).State;
    //this is when you collect only one item.
    public void CollectSingleResult(TreeView id)
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
            TreeRecipe recipe = recipes.Single(x => x.TreeName == item.Name);
            TreeInstance tree = new(recipe, treeCollecting);
            tree.Unlocked = item.Unlocked;
            _trees.Add(tree);
        }
    }
    // Tick method called by game timer
    public void UpdateTick()
    {
        _trees.ForConditionalItems(x => x.Unlocked, tree => tree.UpdateTick());
    }
}