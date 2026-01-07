namespace Phase03ConcurrentPlayerSessions.Data.Crops;
public class BasicCropPolicy : ICropPolicy
{
    Task<bool> ICropPolicy.CanLockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        return Task.FromResult(false);
    }

    Task<bool> ICropPolicy.CanLockGrowSlotAsync(BasicList<CropSlotState> slots)
    {
        return Task.FromResult(false);
    }

    Task<bool> ICropPolicy.CanUnlockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        return Task.FromResult(false);
    }

    Task<bool> ICropPolicy.CanUnlockGrowSlotsAsync(BasicList<CropSlotState> slots, int slotsToUnlock)
    {
        return Task.FromResult(false);
    }

    Task ICropPolicy.LockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        throw new NotImplementedException();
    }

    Task ICropPolicy.LockGrowSlotAsync(BasicList<CropSlotState> slots)
    {
        throw new NotImplementedException();
    }

    Task ICropPolicy.UnlockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        throw new NotImplementedException();
    }

    Task ICropPolicy.UnlockGrowSlotsAsync(BasicList<CropSlotState> slots, int slotsToUnlock)
    {
        throw new NotImplementedException();
    }
}