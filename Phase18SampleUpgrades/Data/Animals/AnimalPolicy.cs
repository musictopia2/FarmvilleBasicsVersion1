namespace Phase18SampleUpgrades.Data.Animals;
public class AnimalPolicy : IAnimalPolicy
{
    private readonly int _maximumUnlocks = 2;
    private readonly int _maximumLocks = 1;
    private int _currentUnlock = 0;
    private int _currentLock = 0;
    private readonly object _lock = new();
    private static AnimalState? GetFirstUnlockedWorskhop(BasicList<AnimalState> animals, string animalName)
    {
        return animals.FirstOrDefault(x => x.Name == animalName && x.Unlocked);
    }
    private static AnimalState? GetFirstLockedWorskhop(BasicList<AnimalState> animals, string animalName)
    {
        return animals.FirstOrDefault(x => x.Name == animalName && x.Unlocked == false);
    }
    Task<bool> IAnimalPolicy.CanLockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        if (_currentLock >= _maximumLocks)
        {
            return Task.FromResult(false);
        }
        AnimalState? firstUnlocked = GetFirstUnlockedWorskhop(animals, animalName);
        if (firstUnlocked is null)
        {
            return Task.FromResult(false);
        }
        if (firstUnlocked.InProgress)
        {
            return Task.FromResult(false); //because there are remaining crafting jobs.
        }
        return Task.FromResult(true);
    }
    async Task<AnimalState> IAnimalPolicy.LockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        //has to trust now.
        lock (_lock)
        {
            AnimalState? firstUnlocked = GetFirstUnlockedWorskhop(animals, animalName);
            if (firstUnlocked is not null)
            {
                firstUnlocked.Unlocked = false;
                _currentLock++;
                return firstUnlocked;
            }
            throw new CustomBasicException("Unable to lock the animal.  Could not find an unlocked animal with the animal name of " + animalName);
        }
    }
    Task<bool> IAnimalPolicy.CanUnlockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        if (_currentUnlock >= _maximumUnlocks)
        {
            return Task.FromResult(false);
        }
        AnimalState? firstLocked = GetFirstLockedWorskhop(animals, animalName);
        if (firstLocked is null)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
    async Task<AnimalState> IAnimalPolicy.UnlockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        lock (_lock)
        {
            AnimalState firstLocked = GetFirstLockedWorskhop(animals, animalName) ?? throw new CustomBasicException("Unable to unlock the animal.  Could not find a locked animal with the building name of " + animalName);
            firstLocked.Unlocked = true;
            _currentUnlock++;
            return firstLocked;
        }
    }
    Task<bool> IAnimalPolicy.CanIncreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        if (animalName == AnimalListClass.Chicken)
        {
            return Task.FromResult(false); //will never allow increasing the options for chickens
        }

        //this is meant to be all or nothing (if one animal increases options, all are done).
        AnimalState? current = animals.FirstOrDefault(x => x.Name == animalName);
        if (current is null)
        {
            return Task.FromResult(false);
        }
        if (current.TotalAllowedOptions == current.TotalPossibleOptions)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true); //for now.
    }
    Task IAnimalPolicy.IncreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        lock (_lock)
        {
            animals.ForConditionalItems(x => x.Name == animalName, current =>
            {
                if (current.TotalAllowedOptions < current.TotalPossibleOptions)
                {
                    current.TotalAllowedOptions++;
                }
            });
            
            return Task.CompletedTask;
        }
    }
    Task<bool> IAnimalPolicy.CanDecreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        AnimalState? current = animals.FirstOrDefault(x => x.Name == animalName);
        if (current is null)
        {
            return Task.FromResult(false);
        }
        if (current.TotalAllowedOptions == 1)
        {
            return Task.FromResult(false); //if you don't even allow 1, then lock the animal.
        }
        return Task.FromResult(true);
    }
    Task IAnimalPolicy.DecreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        lock (_lock)
        {
            animals.ForConditionalItems(x => x.Name == animalName, current =>
            {
                if (current.TotalAllowedOptions > 1)
                {
                    current.TotalAllowedOptions--;
                }
            });
            return Task.CompletedTask;
        }
    }
}