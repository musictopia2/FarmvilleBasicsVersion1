namespace Phase06HarvestingMultipleCrops.Services;
public class GameState : IGameTimer
{
    public object Lock = new ();
    public BasicList<Field> Fields { get; private set; } = [];
    private readonly CropRegistry _registry;

    // Start empty
    public Dictionary<int, int> Inventory { get; } = [];

    public GameState()
    {
        // Initialize 8 fields
        _registry = new ();
        8.Times(() =>
        {
            Fields.Add(new Field());
        });
    }
    public int GetInventory(EnumCropType crop)
    {
        return Inventory.TryGetValue(crop.Value, out int count) ? count : 0;
    }
    public bool CanPlant(Field field, EnumCropType crop)
    {
        lock (Lock)
        {
            if (field == null || field.State != EnumFieldState.Empty)
            {
                return false;
            }

            // Normal case: have at least 1 of the crop
            if (GetInventory(crop) > 0)
            {
                return true;
            }

            // Special rule: if player has 0 of a crop but no fields are currently growing,
            // allow planting one to avoid locking the game.
            // Special rule: allow planting one if nothing is growing
            var anyGrowing = Fields.Any(f => f.State == EnumFieldState.Growing && f.Crop == crop);
            return anyGrowing == false;
        }
    }
    public bool Plant(Field field, EnumCropType crop)
    {
        lock (Lock)
        {
            if (CanPlant(field, crop) == false)
            {
                return false;
            }

            if (GetInventory(crop) > 0)
            {
                Inventory[crop.Value]--; // safe because key exists or GetInventory returns 0
            }
            CropModel temp = _registry.GetByName(crop);
            field.Plant(crop, temp.Duration);

            // Deduct wheat only if available; do not go negative. If Wheat == 0
            // and CanPlant allowed due to no growing fields, permit the plant without deduction.
            return true;
        }
    }
    private void AddInventory(EnumCropType crop, int amount)
    {
        
        if (Inventory.ContainsKey(crop.Value))
        {
            Inventory[crop.Value] += amount;
        }
        else
        {
            Inventory[crop.Value] = amount;
        }
    }
    public void Harvest(Field field)
    {
        lock (Lock)
        {

            if (field.Crop is null)
            {
                throw new CustomBasicException("No crop");
            }
            AddInventory(field.Crop.Value, 2);
            field.Clear();
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