namespace Phase11SingleHabitat.Services;
public class GameState : IGameTimer
{
    public int Honey { get; private set; } = 0; //you will have 0 honey.   so at first, you receive 2 of them, etc.
    public object Lock = new ();
    public BasicList<Habitat> Habitats { get; private set; } = [];
    public GameState()
    {
        // Initialize 2 habitats
        2.Times(() =>
        {
            Habitats.Add(new Habitat());
        });
    }
    public bool CanPlant(Habitat habitat)
    {
        lock (Lock)
        {
            if (habitat == null || habitat.State != EnumHabitatState.Empty)
            {
                return false;
            }

            // Normal case: have at least 1 honey
            if (Honey > 0)
            {
                return true;
            }

            // Special rule: if player has 0 honey but no habitats are currently growing,
            // allow planting one to avoid locking the game.
            if (Honey == 0)
            {
                var anyGrowing = Habitats.Any(f => f.State == EnumHabitatState.Growing);
                return anyGrowing == false;
            }
            return false;
        }
    }
    public bool Plant(Habitat habitat)
    {
        lock (Lock)
        {
            if (CanPlant(habitat) == false)
            {
                return false;
            }

            // Deduct honey only if available; do not go negative. If Wheat == 0
            // and CanPlant allowed due to no growing fields, permit the plant without deduction.
            if (Honey > 0)
            {
                Honey -= 1;
            }

            habitat.Plant();
            return true;
        }
    }
    public void Harvest(Habitat field)
    {
        lock (Lock)
        {
            Honey += 2;
            field.Clear();
        }
    }
    void IGameTimer.Tick()
    {
        //this only focus on harvesting honey alone.
        lock (Lock)
        {
            foreach (var f in Habitats)
            {
                f.UpdateTick();
            }
        }
    }
}