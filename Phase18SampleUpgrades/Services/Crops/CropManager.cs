namespace Phase18SampleUpgrades.Services.Crops;
public class CropManager(ICropInstances cropInstances,
    ICropRegistry registry,
    Inventory inventory,
    ICropPolicy cropPolicy
    )
{
    private readonly BasicList<CropInstance> _crops = [];
    public object Lock = new();
    private BasicList<CropRecipe> _recipes = [];
    private BasicList<CropDataModel> _allCropDefinitions = [];
    public BasicList<string> UnlockedRecipes => _allCropDefinitions.Where(x => x.Unlocked).Select(x => x.Item).ToBasicList(); //so if you change the list, won't change this.
    public BasicList<Guid> GetUnlockedCrops => _crops.Where(x => x.Unlocked).Select(x => x.Id).ToBasicList();
    private BasicList<CropState> GetCropStates()
    {
        BasicList<CropState> output = [];
        foreach (var item in _crops)
        {
            output.Add(new CropState()
            {
                State = item.State,
                Unlocked = item.Unlocked,
                Id = item.Id
            });
        }
        return output;
    }
    public async Task<bool> CanUnlockCropAsync(string name)
    {
        var policy = await cropPolicy.CanUnlockCropAsync(_allCropDefinitions.ToBasicList(), name);
        return policy;
    }
    public Task UnlockCropAsync(string name)
    {
        return cropPolicy.UnlockCropAsync(_allCropDefinitions.ToBasicList(), name);
    }
    public async Task<bool> CanLockCropAsync(string name)
    {
        var policy = await cropPolicy.CanLockCropAsync(_allCropDefinitions.ToBasicList(), name);
        return policy;
    }
    private void UpdateInstances(BasicList<CropState> list)
    {
        list.ForEach(i =>
        {
            var item = _crops.Single(x => x.Id == i.Id);
            item.Unlocked = i.Unlocked;
        });
    }
    public Task LockCropAsync(string name)
    {
        return cropPolicy.LockCropAsync(_allCropDefinitions.ToBasicList(), name);
    }
    public async Task<bool> CanUnlockGrowSlotsAsync(int slots)
    {
        var list = GetCropStates();
        var policy = await cropPolicy.CanUnlockGrowSlotsAsync(list, slots);
        return policy;
    }
    public async Task UnlockGrowSlotsAsync(int slots)
    {
        var list = GetCropStates();
        await cropPolicy.UnlockGrowSlotsAsync(list, slots);
        UpdateInstances(list);
    }
    public async Task<bool> CanLockGrowSlotsAsync()
    {
        var list = GetCropStates();
        var policy = await cropPolicy.CanLockGrowSlotAsync(list);
        return policy;
    }
    public async Task LockGrowSlotsAsync()
    {
        var list = GetCropStates();
        await cropPolicy.LockGrowSlotAsync(list);
        UpdateInstances(list);
    }


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
            CropRecipe temp = _recipes.Single(x => x.Item == item);
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
        _recipes = await registry.GetCropsAsync();
        CropSystemState system = await cropInstances.GetCropInstancesAsync();
        system.Slots.ForEach(x =>
        {
            CropInstance crop = new();
            crop.Unlocked = x.Unlocked;
            _crops.Add(crop);
        });
        _allCropDefinitions = system.Crops.ToBasicList();
    }
    public void UpdateTick()
    {
        _crops.ForConditionalItems(x => x.Unlocked, crop => crop.UpdateTick());
    }
}