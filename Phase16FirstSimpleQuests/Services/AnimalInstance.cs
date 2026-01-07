namespace Phase16FirstSimpleQuests.Services;
public class AnimalInstance(AnimalRecipe recipe)
{
    public int OutputReady { get; private set; } = 0;
    public EnumAnimalState State { get; set; } = EnumAnimalState.None;
    public TimeSpan? Duration { get; private set; }
    public DateTime? StartedAt { get; private set; }
    private EnumQuantity? _quantitySelected;
    public int Required(EnumQuantity quantity)
    {
        AnimalProductionOption option = recipe.GetProduction(quantity);
        return option.Input;
    }
    public int Returned(EnumQuantity quantity)
    {
        AnimalProductionOption option = recipe.GetProduction(quantity);
        return option.Output;
    }
    public int AmountInProgress
    {
        get
        {
            if (_quantitySelected is null)
            {
                throw new CustomBasicException("There was nothing selected");
            }
            return recipe.GetProduction(_quantitySelected.Value).Output;
        }
    }
    public TimeSpan GetDuration(EnumQuantity quantity)
    {
        AnimalProductionOption option = recipe.GetProduction(quantity);
        return option.Duration;
    }
    public void Produce(EnumQuantity quantity)
    {
        if (State != EnumAnimalState.None)
        {
            return;
        }
        _quantitySelected = quantity;
        State = EnumAnimalState.Producing;
        OutputReady = Returned(quantity);
        Duration = GetDuration(quantity);
        StartedAt = DateTime.Now;
    }
    public void UpdateTick()
    {
        if (State != EnumAnimalState.Producing || StartedAt is null || Duration is null)
        {
            return;
        }
        var elapsed = DateTime.Now - StartedAt.Value;
        if (elapsed >= Duration)
        {
            State = EnumAnimalState.Collecting;
            StartedAt = null;
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
            _quantitySelected = null;
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