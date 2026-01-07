namespace Phase07Images.Services.Animals;
public class AnimalInstance(AnimalRecipe recipe)
{
    public Guid Id { get; } = Guid.NewGuid(); // unique per instance
    public bool Unlocked { get; set; } = true;
    public BasicList<AnimalProductionOption> GetUnlockedProductionOptions() => recipe.Options.Take(ProductionOptionsAllowed).ToBasicList();
    public int ProductionOptionsAllowed { get; set; }
    public int TotalProductionOptions => recipe.Options.Count;
    public string Name => recipe.Animal;
    public int OutputReady { get; private set; } = 0;
    public EnumAnimalState State { get; set; } = EnumAnimalState.None;
    public TimeSpan? Duration { get; private set; }
    public DateTime? StartedAt { get; private set; }
    private int? _selected;
    public void Load(AnimalAutoResumeModel animal)
    {
        State = animal.State;
        OutputReady = animal.OutputReady;
        Duration = animal.Duration;
        StartedAt = animal.StartedAt;
        ProductionOptionsAllowed = animal.ProductionOptionsAllowed;
        Unlocked = animal.Unlocked;
        _selected = animal.Selected;
    }
    public AnimalAutoResumeModel GetAnimalForSaving
    {
        get
        {
            return new()
            {
                Name = Name,
                Duration = Duration,
                StartedAt = StartedAt,
                Unlocked = Unlocked,
                OutputReady = OutputReady,
                ProductionOptionsAllowed = ProductionOptionsAllowed,
                State = State,
                Selected = _selected
            };
        }
    }
    public string RequiredName(int selected)
    {
        AnimalProductionOption option = recipe.Options[selected];
        return option.Required;
    }
    public string ReceivedName
    {
        get
        {
            if (_selected is null)
            {
                throw new CustomBasicException("There was nothing selected");
            }
            AnimalProductionOption option = recipe.Options[_selected.Value];
            return option.Output.Item;
        }
    }
    public int RequiredCount(int selected)
    {
        AnimalProductionOption option = recipe.Options[selected];
        return option.Input;
    }
    public int Returned(int selected)
    {
        AnimalProductionOption option = recipe.Options[selected];
        return option.Output.Amount;
    }
    public int AmountInProgress
    {
        get
        {
            if (_selected is null)
            {
                throw new CustomBasicException("There was nothing selected");
            }
            return recipe.Options[_selected.Value].Output.Amount;
        }
    }
    public TimeSpan GetDuration(int selected)
    {
        AnimalProductionOption option = recipe.Options[selected];
        return option.Duration;
    }
    public void Produce(int selected)
    {
        if (State != EnumAnimalState.None)
        {
            return;
        }
        _selected = selected;
        State = EnumAnimalState.Producing;
        OutputReady = Returned(selected);
        Duration = GetDuration(selected);
        StartedAt = DateTime.Now;
    }
    private bool _needsSaving;
    public bool NeedsToSave => _needsSaving;
    public void UpdateTick()
    {
        _needsSaving = false;
        if (State != EnumAnimalState.Producing || StartedAt is null || Duration is null)
        {
            return;
        }
        var elapsed = DateTime.Now - StartedAt.Value;
        if (elapsed >= Duration)
        {
            State = EnumAnimalState.Collecting;
            StartedAt = null;
            _needsSaving = true;
        }
    }
    public void Collect()
    {
        if (OutputReady <= 0)
        {
            return;
        }
        OutputReady--;
        if (OutputReady == 0)
        {
            State = EnumAnimalState.None; //you already got all the milk you need.
            _selected = null;
        }
    }
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumAnimalState.Producing || StartedAt is null)
            {
                return null;
            }
            var elapsed = DateTime.Now - StartedAt.Value;
            var remaining = Duration - elapsed;
            return remaining > TimeSpan.Zero
                ? remaining
                : TimeSpan.Zero;
        }
    }
}