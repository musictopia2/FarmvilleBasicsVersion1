namespace Phase11SingleHabitat.Services;
public class Habitat
{
    public EnumHabitatState State { get; set; } = EnumHabitatState.Empty;
    public DateTime? PlantedAt { get; set; }
    public TimeSpan GrowTime { get; set; } = TimeSpan.FromMinutes(1); //take longer.  normally 45 minutes but take less time because of testing.
    public TimeSpan? ReadyTime
    {
        get
        {
            if (State != EnumHabitatState.Growing || PlantedAt is null)
            {
                return null;
            }
            var elapsed = DateTime.Now - PlantedAt.Value;
            var remaining = GrowTime - elapsed;
            return remaining > TimeSpan.Zero
                ? remaining
                : TimeSpan.Zero;
        }
    }
    public void Plant()
    {
        State = EnumHabitatState.Growing;
        PlantedAt = DateTime.Now;
    }
    public void UpdateTick()
    {
        if (State != EnumHabitatState.Growing || PlantedAt == null) return;
        var elapsed = DateTime.Now - PlantedAt.Value;
        if (elapsed >= GrowTime)
        {
            State = EnumHabitatState.Ready;
            PlantedAt = null;
        }
    }
    public void Clear()
    {
        State = EnumHabitatState.Empty;
        PlantedAt = null;
    }
}