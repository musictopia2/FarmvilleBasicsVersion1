namespace Phase18SampleUpgrades.Services.Crops;
public interface ICropPolicy
{
    // Crop types (what crops are available)
    Task<bool> CanUnlockCropAsync(BasicList<CropDataModel> crops, string cropName);
    Task UnlockCropAsync(BasicList<CropDataModel> crops, string cropName);
    Task<bool> CanLockCropAsync(BasicList<CropDataModel> crops, string cropName);
    Task LockCropAsync(BasicList<CropDataModel> crops, string cropName);

    // Grow slots (how many can be grown at once)
    Task<bool> CanUnlockGrowSlotsAsync(BasicList<CropState> slots, int slotsToUnlock);
    Task UnlockGrowSlotsAsync(BasicList<CropState> slots, int slotsToUnlock);
    Task<bool> CanLockGrowSlotAsync(BasicList<CropState> slots);
    Task LockGrowSlotAsync(BasicList<CropState> slots);
}