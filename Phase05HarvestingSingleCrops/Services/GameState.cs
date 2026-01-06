namespace Phase05HarvestingSingleCrops.Services;
public class GameState : IGameTimer
{
    public int Wheat { get; private set; } = 0; //you will have 0 wheat.   so at first, you receive 2 of them, etc.
    public object Lock = new ();
    public BasicList<Field> Fields { get; private set; } = [];

    public GameState()
    {
        // Initialize 8 fields
        8.Times(() =>
        {
            Fields.Add(new Field());
        });
    }

    public bool CanPlant(Field field)
    {
        lock (Lock)
        {
            if (field == null || field.State != EnumFieldState.Empty)
            {
                return false;
            }

            // Normal case: have at least 1 wheat
            if (Wheat > 0)
            {
                return true;
            }

            // Special rule: if player has 0 wheat but no fields are currently growing,
            // allow planting one to avoid locking the game.
            if (Wheat == 0)
            {
                var anyGrowing = Fields.Any(f => f.State == EnumFieldState.Growing);
                return anyGrowing == false;
            }
            return false;
        }
    }
    public bool Plant(Field field)
    {
        lock (Lock)
        {
            if (CanPlant(field) == false)
            {
                return false;
            }

            // Deduct wheat only if available; do not go negative. If Wheat == 0
            // and CanPlant allowed due to no growing fields, permit the plant without deduction.
            if (Wheat > 0)
            {
                Wheat -= 1;
            }

            field.Plant();
            return true;
        }
    }
    public void Harvest(Field field)
    {
        lock (Lock)
        {
            //if (!CanHarvest(field)) return false;
            // Harvest gives +2 wheat
            Wheat += 2;
            //if (SiloWheat > SiloCapacity) SiloWheat = SiloCapacity;
            field.Clear();
            //return true;
        }
    }
    void IGameTimer.Tick()
    {
        //this only focus on harvesting wheat alone.
        lock (Lock)
        {
            foreach (var f in Fields)
            {
                f.UpdateTick();
            }
        }
    }
}