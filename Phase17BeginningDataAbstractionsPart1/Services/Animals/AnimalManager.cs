namespace Phase17BeginningDataAbstractionsPart1.Services.Animals;
public class AnimalManager(Inventory inventory,
    IAnimalRegistry animalRecipes,
    IAnimalInstances animalInstances)
{
    private readonly BasicList<AnimalInstance> _animals = [];
    public BasicList<AnimalSummary> GetAllAnimals
    {
        get
        {
            BasicList<AnimalSummary> output = [];
            _animals.ForEach(t =>
            {
                AnimalSummary summary = new()
                {
                    Id = t.Id,
                    Name = t.Name
                };
                output.Add(summary);
            });
            return output;
        }
    }
    private AnimalInstance GetAnimalById(Guid id)
    {
        var tree = _animals.SingleOrDefault(t => t.Id == id) ?? throw new CustomBasicException($"Animal with Id {id} not found.");
        return tree;
    }
    private AnimalInstance GetAnimalById(AnimalSummary id) => GetAnimalById(id.Id);
    public BasicList<AnimalProductionOption> GetProductionOptions(AnimalSummary animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.GetProductionOptions().ToBasicList();
    }
    public string GetName(AnimalSummary animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.Name;
    }
    public int Required(AnimalSummary animal, int selected) => GetAnimalById(animal).RequiredCount(selected);
    public int Returned(AnimalSummary animal, int selected) => GetAnimalById(animal).Returned(selected);
    public bool CanProduce(AnimalSummary animal, int selected)
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
    public void Produce(AnimalSummary animal, int selected)
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
    public void CollectSingle(AnimalSummary animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        string selectedName = instance.ReceivedName;
        instance.Collect();
        inventory.Add(selectedName, 1);
    }
    public EnumAnimalState GetState(AnimalSummary animal) => GetAnimalById(animal).State;
    public int Left(AnimalSummary animal) => GetAnimalById(animal).OutputReady;
    public string TimeLeftForResult(AnimalSummary animal)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.ReadyTime!.Value.GetTimeString;
    }
    public string Duration(AnimalSummary animal, int selected)
    {
        AnimalInstance instance = GetAnimalById(animal);
        return instance.GetDuration(selected).GetTimeString;
    }
    public int InProgress(AnimalSummary animal) => GetAnimalById(animal).AmountInProgress;
    public async Task PopulateAnimalsAsync()
    {
        BasicList<AnimalRecipe> recipes = await animalRecipes.GetAnimalsAsync();
        var ours = await animalInstances.GetAnimalInstancesAsync();
        foreach (var item in ours)
        {
            AnimalRecipe recipe = recipes.Single(x => x.Animal == item);
            AnimalInstance animal = new(recipe);
            _animals.Add(animal);
        }
    }
    public void UpdateTick()
    {
        _animals.ForEach(animal => animal.UpdateTick());
    }
}