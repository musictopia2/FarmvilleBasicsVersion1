namespace Phase07SingleAnimal.Services;
public class GameState : IGameTimer
{
    public int WheatInventory { get; set; } = 11;
    public int MilkInventory { get; set; } = 0; //start with no milk.
    //this focus on milk so should be okay.
    readonly CowClass _cow = new();
    public int WheatRequired(EnumQuantity quantity) => _cow.WheatRequired(quantity);
    public int MilkReturned(EnumQuantity quantity) => _cow.MilkReturned(quantity);
    public bool CanProduceMilk(EnumQuantity quantity)
    {
        if (_cow.State != EnumAnimalState.None)
        {
            return false;
        }
        int required = _cow.WheatRequired(quantity);
        return WheatInventory >= required;
    }
    public void ProduceMilk(EnumQuantity quantity)
    {
        if (CanProduceMilk(quantity) == false)
        {
            throw new CustomBasicException("Cannot produce milk.  Should had used CanProduceMilk function");
        }
        int required = _cow.WheatRequired(quantity);
        WheatInventory -= required;
        _cow.ProduceMilk(quantity);
    }
    //eventually cannot collect milk if you don't have enough inventory for it (later).
    public void CollectMilk()
    {
        if (_cow.MilkReady <= 0)
        {
            return;
        }
        MilkInventory++;
        _cow.CollectMilk();
    }
    public EnumAnimalState GetCowState => _cow.State;
    public int MilkLeft => _cow.MilkReady;
    public string TimeLeftForCow => _cow.ReadyTime!.Value.GetTimeString;
    public string CowDuration(EnumQuantity quantity) => _cow.TimeForMilk(quantity).GetTimeString;
    void IGameTimer.Tick()
    {
        _cow.UpdateTick();
    }
}