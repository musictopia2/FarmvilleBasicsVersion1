namespace Phase08MultipleAnimals.Services;
public class GameState : IGameTimer
{
    readonly Inventory _inventory;
    readonly AnimalRegistry _registry;
    AnimalInstance _cowInstance;
    AnimalInstance _chickenInstance;
    public GameState()
    {
        _inventory = new();
        _inventory.Add(EnumItemType.Wheat, 11);
        _inventory.Add(EnumItemType.Corn, 5);
        _registry = new();
        AnimalRecipe recipe = _registry.GetByName(EnumItemType.Milk);
        _cowInstance = new(recipe);
        recipe = _registry.GetByName(EnumItemType.Eggs);
        _chickenInstance = new(recipe);
    }
    public Func<Task>? StateChanged { get; set; }
    public int GetInventoryCount(EnumItemType item)
    {
        return _inventory.Get(item);
    }
    public int CornRequired(EnumQuantity quantity) => _chickenInstance.Required(quantity);
    public int EggsReturned (EnumQuantity quantity) => _chickenInstance.Returned(quantity);
    public bool CanProduceEggs(EnumQuantity quantity)
    {
        if (_chickenInstance.State != EnumAnimalState.None)
        {
            return false;
        }
        int required = _chickenInstance.Required(quantity);
        int cornInventory = _inventory.Get(EnumItemType.Corn);
        return cornInventory >= required;
    }
    public void ProduceEggs(EnumQuantity quantity)
    {
        if (CanProduceEggs(quantity) == false)
        {
            throw new CustomBasicException("Cannnot produce eggs.  Should had used CanProduceEggs function");
        }
        int required = _chickenInstance.Required(quantity);
        _inventory.Consume(EnumItemType.Corn, required);
        _chickenInstance.Produce(quantity);
        StateChanged?.Invoke();
    }
    public void CollectEggs()
    {
        if (_chickenInstance.OutputReady <= 0)
        {
            return;
        }
        _inventory.Add(EnumItemType.Eggs, 1);
        _chickenInstance.Collect();
        StateChanged?.Invoke();
    }
    public EnumAnimalState GetChickenState => _chickenInstance.State;
    public int EggsLeft => _chickenInstance.OutputReady;
    public string TimeLeftForChicken => _chickenInstance.ReadyTime!.Value.GetTimeString;
    public string ChickenDuration(EnumQuantity quantity) => _chickenInstance.GetDuration(quantity).GetTimeString;
    public int WheatRequired(EnumQuantity quantity) => _cowInstance.Required(quantity);
    public int MilkReturned(EnumQuantity quantity) => _cowInstance.Returned(quantity);
    public bool CanProduceMilk(EnumQuantity quantity)
    {
        if (_cowInstance.State != EnumAnimalState.None)
        {
            return false;
        }
        int required = _cowInstance.Required(quantity);
        int wheatInventory = _inventory.Get(EnumItemType.Wheat);
        return wheatInventory >= required;
    }
    public void ProduceMilk(EnumQuantity quantity)
    {
        if (CanProduceMilk(quantity) == false)
        {
            throw new CustomBasicException("Cannot produce milk.  Should had used CanProduceMilk function");
        }
        int required = _cowInstance.Required(quantity);
        _inventory.Consume(EnumItemType.Wheat, required);
        _cowInstance.Produce(quantity);
        StateChanged?.Invoke();
    }
    //eventually cannot collect milk if you don't have enough inventory for it (later).
    public void CollectMilk()
    {
        if (_cowInstance.OutputReady <= 0)
        {
            return;
        }
        _inventory.Add(EnumItemType.Milk, 1);
        _cowInstance.Collect();
        StateChanged?.Invoke();
    }
    public EnumAnimalState GetCowState => _cowInstance.State;
    public int MilkLeft => _cowInstance.OutputReady;
    public string TimeLeftForCow => _cowInstance.ReadyTime!.Value.GetTimeString;
    public string CowDuration(EnumQuantity quantity) => _cowInstance.GetDuration(quantity).GetTimeString;
    void IGameTimer.Tick()
    {
        _chickenInstance.UpdateTick();
        _cowInstance.UpdateTick();
    }
}