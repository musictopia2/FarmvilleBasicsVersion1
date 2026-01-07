namespace Phase01MultipleFarmStyles.Data.Crops;
public class CountryCropPolicy : ICropPolicy
{
    //now will always allow to keep the testing simple.
    private readonly object _lock = new();
    Task<bool> ICropPolicy.CanUnlockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        var crop = crops.SingleOrDefault(x => x.Item == cropName);
        if (crop is null)
        {
            return Task.FromResult(false);
        }
        if (crop.Unlocked)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
    async Task ICropPolicy.UnlockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        lock (_lock)
        {
            var crop = crops.SingleOrDefault(x => x.Item == cropName);
            if (crop is null)
            {
                return;
            }
            crop.Unlocked = true;
        }
    }
    Task<bool> ICropPolicy.CanLockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        var crop = crops.SingleOrDefault(x => x.Item == cropName);
        if (crop is null)
        {
            return Task.FromResult(false);
        }
        if (crop.Unlocked == false)
        {
            return Task.FromResult(false);
        }
        if (crop.Item == CountryItemList.Corn)
        {
            return Task.FromResult(false); //once you unlock corn, cannot lock it back up for this version.
        }
        int count = crops.Count(x => x.Unlocked);
        if (count == 1)
        {
            return Task.FromResult(false); //has to allow at least one crop.
        }
        return Task.FromResult(true);
    }
    async Task ICropPolicy.LockCropAsync(BasicList<CropDataModel> crops, string cropName)
    {
        lock (_lock)
        {
            var crop = crops.SingleOrDefault(x => x.Item == cropName);
            if (crop is null)
            {
                return;
            }
            crop.Unlocked = false;
        }
    }
    Task<bool> ICropPolicy.CanUnlockGrowSlotsAsync(BasicList<CropSlotState> slots, int slotsToUnlock)
    {
        if (slots.Count == 0)
        {
            return Task.FromResult(false); //try this instead now.  if hidden bug, too bad.
            //throw new CustomBasicException("Should had at least one slot.  Rethink");
        }
        int lockedSlots = slots.Count(x => x.Unlocked == false);
        if (slotsToUnlock > lockedSlots)
        {
            return Task.FromResult(false);
        }
        if (slotsToUnlock > 4)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
    async Task ICropPolicy.UnlockGrowSlotsAsync(BasicList<CropSlotState> slots, int slotsToUnlock)
    {
        lock (_lock)
        {
            var list = slots.Where(x => x.Unlocked == false).Take(slotsToUnlock).ToBasicList();
            list.ForEach(x => x.Unlocked = true);
        }
    }
    private int _lockedEver = 0;
    Task<bool> ICropPolicy.CanLockGrowSlotAsync(BasicList<CropSlotState> slots)
    {
        if (_lockedEver > 3)
        {
            return Task.FromResult(false); //you can only lock 3 times.
        }
        var slot = slots.FirstOrDefault(x => x.State == EnumCropState.Empty && x.Unlocked);
        if (slot is null)
        {
            return Task.FromResult(false);
        }
        if (slots.Count(x => x.Unlocked == false) == 1)
        {
            return Task.FromResult(false); //you must allow at least one crop.
        }
        return Task.FromResult(true);
    }
    async Task ICropPolicy.LockGrowSlotAsync(BasicList<CropSlotState> slots)
    {
        lock (_lock)
        {
            var slot = slots.FirstOrDefault(x => x.State == EnumCropState.Empty && x.Unlocked);
            if (slot is null)
            {
                return;
            }
            _lockedEver++;
            slot.Unlocked = false;
        }
    }
}