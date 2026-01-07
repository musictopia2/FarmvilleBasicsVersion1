namespace Phase10MultipleTrees.Services;
public class GameState : IGameTimer
{
    public const int TotalFromTrees = 4;
    readonly Inventory _inventory;
    readonly TreeRegistry _registry;
    readonly TreeInstance _appleInstance;
    readonly TreeInstance _peachInstance;
    public GameState()
    {
        _inventory = new();
        _registry = new();
        TreeRecipe recipe = _registry.GetByName(EnumItemType.Apples);
        _appleInstance = new(recipe);
        recipe = _registry.GetByName(EnumItemType.Peaches);
        _peachInstance = new(recipe);
    }
    public Func<Task>? StateChanged { get; set; }
    public int GetInventoryCount(EnumItemType item)
    {
        return _inventory.Get(item);
    }
    //for now, not generic.  later be more generic.
    public int ApplesReady => _appleInstance.TreesReady;
    public string TimeLeftForApples => _appleInstance.ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetAppleState => _appleInstance.State;
    public void CollectApple()
    {
        _appleInstance.CollectTree();
        _inventory.Add(EnumItemType.Apples, 1);
        StateChanged?.Invoke();
    }
    public int PeachesReady => _peachInstance.TreesReady;
    public string TimeLeftForPeaches => _peachInstance.ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetPeachState => _peachInstance.State;
    public void CollectPeach()
    {
        _peachInstance.CollectTree();
        _inventory.Add(EnumItemType.Peaches, 1);
        StateChanged?.Invoke();
    }
    void IGameTimer.Tick()
    {
        _appleInstance.UpdateTick();
        _peachInstance.UpdateTick();
    }
}