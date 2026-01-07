
namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Animals;

public class BasicAnimalPolicy : IAnimalPolicy
{
    Task<bool> IAnimalPolicy.CanDecreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        return Task.FromResult(false);
    }

    Task<bool> IAnimalPolicy.CanIncreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        return Task.FromResult(false);
    }

    Task<bool> IAnimalPolicy.CanLockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        return Task.FromResult(false);
    }

    Task<bool> IAnimalPolicy.CanUnlockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        return Task.FromResult(false);
    }

    Task IAnimalPolicy.DecreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        throw new NotImplementedException();
    }

    Task IAnimalPolicy.IncreaseOptionsAsync(BasicList<AnimalState> animals, string animalName)
    {
        throw new NotImplementedException();
    }

    Task<AnimalState> IAnimalPolicy.LockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        throw new NotImplementedException();
    }

    Task<AnimalState> IAnimalPolicy.UnlockAnimalAsync(BasicList<AnimalState> animals, string animalName)
    {
        throw new NotImplementedException();
    }
}