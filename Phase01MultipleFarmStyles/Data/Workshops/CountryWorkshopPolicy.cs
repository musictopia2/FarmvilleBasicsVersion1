namespace Phase01MultipleFarmStyles.Data.Workshops;
public class CountryWorkshopPolicy : IWorkshopPolicy
{
    private readonly int _maximumUnlocks = 2;
    private readonly int _maximumLocks = 1;
    private int _currentUnlock = 0;
    private int _currentLock = 0;
    private readonly object _lock = new();
    private static WorkshopState? GetFirstUnlockedWorskhop(BasicList<WorkshopState> workshops, string buildingName)
    {
        return workshops.FirstOrDefault(x => x.Name == buildingName && x.Unlocked);
    }
    private static WorkshopState? GetFirstLockedWorskhop(BasicList<WorkshopState> workshops, string buildingName)
    {
        return workshops.FirstOrDefault(x => x.Name == buildingName && x.Unlocked == false);
    }
    Task<bool> IWorkshopPolicy.CanLockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        if (_currentLock >= _maximumLocks)
        {
            return Task.FromResult(false);
        }
        WorkshopState? firstUnlocked = GetFirstUnlockedWorskhop(workshops, buildingName);
        if (firstUnlocked is null)
        {
            return Task.FromResult(false);
        }
        if (firstUnlocked.RemainingCraftingJobs)
        {
            return Task.FromResult(false); //because there are remaining crafting jobs.
        }
        return Task.FromResult(true);
    }
    async Task<WorkshopState> IWorkshopPolicy.LockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        //has to trust now.
        lock (_lock)
        {
            WorkshopState? firstUnlocked = GetFirstUnlockedWorskhop(workshops, buildingName);
            if (firstUnlocked is not null)
            {
                firstUnlocked.Unlocked = false;
                _currentLock++;
                return firstUnlocked;
            }
            throw new CustomBasicException("Unable to lock the workshop.  Could not find an unlocked workshop with the building name of " + buildingName);
        }
    }
    Task<bool> IWorkshopPolicy.CanUnlockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        if (_currentUnlock >= _maximumUnlocks)
        {
            return Task.FromResult(false);
        }
        WorkshopState? firstLocked = GetFirstLockedWorskhop(workshops, buildingName);
        if (firstLocked is null)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
    async Task<WorkshopState> IWorkshopPolicy.UnlockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        lock (_lock)
        {
            WorkshopState firstLocked = GetFirstLockedWorskhop(workshops, buildingName) ?? throw new CustomBasicException("Unable to unlock the workshop.  Could not find a locked workshop with the building name of " + buildingName);
            firstLocked.Unlocked = true;
            _currentUnlock++;
            return firstLocked;
        }
    }
}
