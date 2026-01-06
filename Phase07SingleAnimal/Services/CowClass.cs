namespace Phase07SingleAnimal.Services;
public class CowClass
{
    //since i am only doing cow, its okay to do here.  later,  will be required to do separately (when doing multiple).
    //refer to phase 5 when i was doing single crops.
    //this is how much milk you will receive
    public int MilkReady { get; private set; } = 0;
    public EnumAnimalState State { get; set; } = EnumAnimalState.None;
    public TimeSpan? MilkDuration { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public int WheatRequired(EnumQuantity quantity)
    {
        if (quantity == EnumQuantity.Single)
        {
            return 3;
        }
        if (quantity == EnumQuantity.Double)
        {
            return 6;
        }
        if (quantity == EnumQuantity.Triple)
        {
            return 9;
        }
        throw new CustomBasicException("Nothing");
    }

    public int MilkReturned(EnumQuantity quantity)
    {
        //for now, cannot do switch expressions on enums
        if (quantity == EnumQuantity.Single)
        {
            return 1;
        }
        if (quantity == EnumQuantity.Double)
        {
            return 2;
        }
        if (quantity == EnumQuantity.Triple)
        {
            return 3;
        }
        throw new CustomBasicException("Out of range");
        //return quantity switch
        //{
        //    EnumQuantity.Single => 1,
        //    EnumQuantity.Double => 2,
        //    EnumQuantity.Triple => 3,
        //    _ => throw new CustomBasicException("Out Of Range")
        //};
    }
    public TimeSpan TimeForMilk(EnumQuantity quantity)
    {
        if (quantity == EnumQuantity.Single)
        {
            return TimeSpan.FromSeconds(30);
        }
        if (quantity == EnumQuantity.Double)
        {
            return TimeSpan.FromMinutes(2);
        }
        if (quantity == EnumQuantity.Triple)
        {
            return TimeSpan.FromMinutes(6);
        }
        throw new CustomBasicException("Out of range");
    }
    public void ProduceMilk(EnumQuantity quantity)
    {
        if (State != EnumAnimalState.None)
        {
            return;
        }
        State = EnumAnimalState.Producing;
        MilkReady = MilkReturned(quantity);
        MilkDuration = TimeForMilk(quantity);
        StartedAt = DateTime.Now;
    }
    public void UpdateTick()
    {
        if (State != EnumAnimalState.Producing || StartedAt is null || MilkDuration is null)
        {
            return;
        }
        var elapsed = DateTime.Now - StartedAt.Value;
        if (elapsed >= MilkDuration)
        {
            State = EnumAnimalState.Collecting;
            StartedAt = null;
        }
    }
    public void CollectMilk()
    {
        if (MilkReady <= 0)
        {
            return;
        }
        MilkReady--;
        if (MilkReady == 0)
        {
            State = EnumAnimalState.None; //you already got all the milk you need.
        }
    }
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumAnimalState.Producing || StartedAt is null)
            {
                return null;
            }
            var elapsed = DateTime.Now - StartedAt.Value;
            var remaining = MilkDuration - elapsed;
            return remaining > TimeSpan.Zero
                ? remaining
                : TimeSpan.Zero;
        }
    }

}
