namespace Phase08MultipleAnimals.Services;
public class AnimalInstance(AnimalRecipe recipe)
{
    public int OutputReady { get; private set; } = 0;
    public EnumAnimalState State { get; set; } = EnumAnimalState.None;
    public TimeSpan? Duration { get; private set; }
    public DateTime? StartedAt { get; private set; }
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