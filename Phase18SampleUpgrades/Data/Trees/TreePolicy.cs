namespace Phase18SampleUpgrades.Data.Trees;
public class TreePolicy : ITreePolicy
{
    private readonly int _maximumUnlocks = 2;
    private readonly int _maximumLocks = 1;
    private int _currentUnlock = 0;
    private int _currentLock = 0;
    private readonly Lock _lock = new();
    private static TreeState? GetFirstUnlockedTree(BasicList<TreeState> trees, string name)
    {
        return trees.FirstOrDefault(x => x.Name == name && x.Unlocked);
    }
    private static TreeState? GetFirstLockedTree(BasicList<TreeState> trees, string name)
    {
        return trees.FirstOrDefault(x => x.Name == name && x.Unlocked == false);
    }
    Task<bool> ITreePolicy.CanLockTreeAsync(BasicList<TreeState> list, string name)
    {
        if (_currentLock >= _maximumLocks)
        {
            return Task.FromResult(false);
        }

        TreeState? firstUnlocked = GetFirstUnlockedTree(list, name);
        if (firstUnlocked is null)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    Task<TreeState> ITreePolicy.LockTreeAsync(BasicList<TreeState> list, string name)
    {
        lock (_lock)
        {
            TreeState? firstUnlocked = GetFirstUnlockedTree(list, name);
            if (firstUnlocked is not null)
            {
                firstUnlocked.Unlocked = false;
                _currentLock++;
                return Task.FromResult(firstUnlocked);
            }

            throw new CustomBasicException(
                "Unable to lock the tree. Could not find an unlocked tree with the name of " + name);
        }
    }

    Task<bool> ITreePolicy.CanUnlockTreeAsync(BasicList<TreeState> list, string name)
    {
        if (_currentUnlock >= _maximumUnlocks)
        {
            return Task.FromResult(false);
        }

        TreeState? firstLocked = GetFirstLockedTree(list, name);
        if (firstLocked is null)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    Task<TreeState> ITreePolicy.UnlockTreeAsync(BasicList<TreeState> list, string name)
    {
        lock (_lock)
        {
            TreeState firstLocked =
                GetFirstLockedTree(list, name)
                ?? throw new CustomBasicException(
                    "Unable to unlock the tree. Could not find a locked tree with the name of " + name);

            firstLocked.Unlocked = true;
            _currentUnlock++;
            return Task.FromResult(firstLocked);
        }
    }
}