namespace Phase18SampleUpgrades.Services.Animals;
public class AnimalManager(Inventory inventory,
    IAnimalRegistry animalRecipes,
    IAnimalInstances animalInstances,
    IAnimalPolicy animalPolicy
    )
{
    private readonly BasicList<AnimalInstance> _animals = [];
    public event Action? OnAnimalsUpdated;
    public BasicList<AnimalView> GetUnlockedAnimals
    {
        get
        {
            BasicList<AnimalView> output = [];
            _animals.ForConditionalItems(x => x.Unlocked, t =>
            {
                AnimalView summary = new()
                {
                    Id = t.Id,
                    Name = t.Name
                };
                output.Add(summary);
            });
            return output;
        }
    }
    public BasicList<AnimalState> GetAllAnimals
    {
        get
        {
            BasicList<AnimalState> output = [];
            _animals.ForEach(t =>
            {
                bool processing = t.State != EnumAnimalState.None;
                output.Add(new()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Unlocked = t.Unlocked,
                    InProgress = processing,
                    TotalPossibleOptions = t.TotalProductionOptions,
                    TotalAllowedOptions = t.ProductionOptionsAllowed
                });
            });
            return output;
        }
    }
    private AnimalInstance GetAnimalById(Guid id)
    {
        var tree = _animals.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Animal with Id {id} not found.");
        return tree;
    }
    private AnimalInstance GetAnimalById(AnimalView id) => GetAnimalById(id.Id);

    public async Task<bool> CanUnlockAnimalAsync(string name)
    {
        var list = GetAllAnimals;
        var policy = await animalPolicy.CanUnlockAnimalAsync(list, name);
        return policy;
    }
    public async Task UnlockAnimalAsync(string name)
    {
        var list = GetAllAnimals;
        var policy = await animalPolicy.UnlockAnimalAsync(list, name);
        UpdateAnimalInstance(policy);
    }
    public async Task<bool> CanLockAnimalAsync(string name)
    {
        var list = GetAllAnimals;
        var policy = await animalPolicy.CanLockAnimalAsync(list, name);
        return policy;
    }
    public async Task LockAnimalAsync(string name)
    {
        var list = GetAllAnimals;
        var policy = await animalPolicy.LockAnimalAsync(list, name);
        UpdateAnimalInstance(policy);
    }
    public async Task<bool> CanIncreaseAnimalOptionsAsync(string name)
    {
        var list = GetAllAnimals;
        var policy = await animalPolicy.CanIncreaseOptionsAsync(list, name);
        return policy;
    }
    public async Task IncreaseAnimalOptionsAsync(string name)
    {
        var list = GetAllAnimals;
        await animalPolicy.IncreaseOptionsAsync(list, name);
        UpdateAnimalOptions(list);
    }
    public async Task<bool> CanDecreaseAnimalOptionsAsync(string name)
    {
        var list = GetAllAnimals;
        var policy = await animalPolicy.CanDecreaseOptionsAsync(list, name);
        return policy;
    }
    public async Task DecreaseAnimalOptionsAsync(string name)
    {
        var list = GetAllAnimals;
        await animalPolicy.DecreaseOptionsAsync(list, name);
        UpdateAnimalOptions(list);
    }
    private void UpdateAnimalOptions(BasicList<AnimalState> list)
    {
        foreach (var item in list)
        {
            var animal = GetAnimalById(item);
            animal.ProductionOptionsAllowed = item.TotalAllowedOptions;
        }
        OnAnimalsUpdated?.Invoke();
    }
    private void UpdateAnimalInstance(AnimalState summary)
    {
        var animal = GetAnimalById(summary);
        animal.Unlocked = summary.Unlocked;
        OnAnimalsUpdated?.Invoke();
    }

    public BasicList<AnimalProductionOption> GetUnlockedProductionOptions(AnimalView animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.GetUnlockedProductionOptions().ToBasicList();
    }
    public string GetName(AnimalView animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.Name;
    }
    public int Required(AnimalView animal, int selected) => GetAnimalById(animal).RequiredCount(selected);
    public int Returned(AnimalView animal, int selected) => GetAnimalById(animal).Returned(selected);
    public bool CanProduce(AnimalView animal, int selected)
    {
        AnimalInstance instance = GetAnimalById(animal);
        if (instance.State != EnumAnimalState.None)
        {
            return false;
        }
        int required = instance.RequiredCount(selected);
        int count = inventory.Get(instance.RequiredName(selected));
        return count >= required;
    }
    public void Produce(AnimalView animal, int selected)
    {
        AnimalInstance instance = GetAnimalById(animal);
        if (CanProduce(animal, selected) == false)
        {
            throw new CustomBasicException("Cannot produce animal.  Should had used CanProduce function");
        }
        int required = instance.RequiredCount(selected);
        inventory.Consume(instance.RequiredName(selected), required);
        instance.Produce(selected);
    }
    public void CollectSingle(AnimalView animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        string selectedName = instance.ReceivedName;
        instance.Collect();
        inventory.Add(selectedName, 1);
    }
    public EnumAnimalState GetState(AnimalView animal) => GetAnimalById(animal).State;
    public int Left(AnimalView animal) => GetAnimalById(animal).OutputReady;
    public string TimeLeftForResult(AnimalView animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.ReadyTime!.Value.GetTimeString;
    }
    public string Duration(AnimalView animal, int selected)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.GetDuration(selected).GetTimeString;
    }
    public int InProgress(AnimalView animal) => GetAnimalById(animal).AmountInProgress;
    public async Task PopulateAnimalsAsync()
    {
        BasicList<AnimalRecipe> recipes = await animalRecipes.GetAnimalsAsync();
        var ours = await animalInstances.GetAnimalInstancesAsync();
        foreach (var item in ours)
        {
            AnimalRecipe recipe = recipes.Single(x => x.Animal == item.Name);
            AnimalInstance animal = new(recipe);
            animal.Unlocked = item.Unlocked;
            animal.ProductionOptionsAllowed = item.UnlockedOptionCount;
            _animals.Add(animal);
        }
    }
    public void UpdateTick()
    {
        _animals.ForConditionalItems(x => x.Unlocked, animal => animal.UpdateTick());
    }
}