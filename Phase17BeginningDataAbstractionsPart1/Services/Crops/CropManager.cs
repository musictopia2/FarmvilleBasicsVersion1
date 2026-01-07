namespace Phase17BeginningDataAbstractionsPart1.Services.Crops;
public class CropManager(ICropCountClass countService,
    ICropRegistry registry,
    Inventory inventory
    )
{
    private readonly BasicList<CropInstance> _crops = [];
    //public BasicList<CropInstance> CropInstances { get; private set; } = [];
    public object Lock = new();
    private BasicList<CropModel> _recipes = [];
    public BasicList<CropModel> Recipes => _recipes.ToBasicList(); //so if you change the list, won't change this.

    public BasicList<Guid> GetAllCrops => _crops.Select(x => x.Id).ToBasicList();

    //all methods related to crops are here now.

    public EnumCropState GetCropState(Guid id) => GetCrop(id).State;
    public string GetTimeLeft(Guid id) => GetCrop(id).ReadyTime?.GetTimeString ?? "";
    public string GetCropName(Guid id) => GetCrop(id).Crop!;

    private CropInstance GetCrop(Guid id)
    => _crops.SingleOrDefault(x => x.Id == id) ??
       throw new CustomBasicException($"Crop with ID {id} not found.");

    //any methods needed goes here.


    public bool CanPlant(Guid id, string item)
    {
        lock (Lock)
        {
            CropInstance crop = GetCrop(id);
            if (crop == null || crop.State != EnumCropState.Empty)
            {
                return false;
            }

            // Normal case: have at least 1 of the crop
            if (inventory.GetInventoryCount(item) > 0)
            {
                return true;
            }

            // Special rule: if player has 0 of a crop but none are currently growing,
            // allow planting one to avoid locking the game.
            // Special rule: allow planting one if nothing is growing
            var anyGrowing = _crops.Any(f => f.State == EnumCropState.Growing && f.Crop == item);
            return anyGrowing == false;
        }
    }
    public void Plant(Guid id, string item)
    {
        lock (Lock)
        {

            if (CanPlant(id, item) == false)
            {
                throw new CustomBasicException("Cannot plant.  Should had called the CanPlant first");
            }
            CropInstance crop = GetCrop(id);
            if (inventory.GetInventoryCount(item) > 0)
            {
                inventory.Consume(item, 1);
            }
            CropModel temp = _recipes.Single(x => x.Item == item);
            crop.Plant(item, temp.Duration);

            // Deduct crop only if available; do not go negative. If Wheat == 0
            // and CanPlant allowed due to no growing fields, permit the plant without deduction.
        }
    }
    public void Harvest(Guid id)
    {
        lock (Lock)
        {
            CropInstance crop = GetCrop(id);
            if (crop.Crop is null)
            {
                throw new CustomBasicException("No crop");
            }
            inventory.Add(crop.Crop, 2);
            crop.Clear();
        }
    }
    public async Task PopulateCropsAsync()
    {
        int maxs = await countService.GetCropCountAsync();
        _recipes = await registry.GetCropsAsync();
        maxs.Times(x =>
        {
            CropInstance crop = new();
            _crops.Add(crop);
        });
    }
    public void UpdateTick()
    {
        _crops.ForEach(crop => crop.UpdateTick());
    }
}