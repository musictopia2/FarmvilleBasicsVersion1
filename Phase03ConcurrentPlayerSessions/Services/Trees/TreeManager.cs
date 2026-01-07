namespace Phase03ConcurrentPlayerSessions.Services.Trees;
public class TreeManager(Inventory inventory
    )
{
    private ITreesCollecting? _treeCollecting;
    private ITreePolicy? _treePolicy;
    private BasicList<TreeRecipe>? _recipes;
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
        CustomBasicException.ThrowIfNull(_treeCollecting);
        return _treeCollecting.TreesCollectedAtTime; // for now
    }
    private TreeInstance GetTreeById(Guid id)
    {
        var tree = _trees.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Tree with Id {id} not found.");
        return tree;
    }
    private TreeInstance GetTreeById(TreeView id) => GetTreeById(id.Id);

    public async Task<bool> CanUnlockTreeAsync(string name)
    {
        if (_treePolicy is null)
        {
            return false;
        }
        var list = GetAllTrees;
        var policy = await _treePolicy.CanUnlockTreeAsync(list, name);
        return policy;
    }

    public async Task UnlockTreeAsync(string name)
    {
        var list = GetAllTrees;
        var policy = await _treePolicy!.UnlockTreeAsync(list, name);
        UpdateTreeInstance(policy);
    }

    public async Task<bool> CanLockTreeAsync(string name)
    {
        if (_treePolicy is null)
        {
            return false;
        }
        var list = GetAllTrees;
        var policy = await _treePolicy.CanLockTreeAsync(list, name);
        return policy;
    }

    public async Task LockTreeAsync(string name)
    {
        var list = GetAllTrees;
        var policy = await _treePolicy!.LockTreeAsync(list, name);
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

    public async Task SetStyleContextAsync(TreeServicesContext context)
    {
        _treePolicy = context.TreePolicy;
        _recipes = await context.TreeRegistry.GetTreesAsync();
        var ours = await context.TreeInstances.GetTreeInstancesAsync();
        _trees.Clear();
        _treeCollecting = context.TreesCollecting;
        //var treeCollecting = context.TreesCollecting;
        foreach (var item in ours)
        {
            TreeRecipe recipe = _recipes.Single(x => x.TreeName == item.Name);
            TreeInstance tree = new(recipe, _treeCollecting);
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