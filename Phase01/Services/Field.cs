using System;

namespace Phase01.Services;

public enum FieldState
{
    Empty,
    Growing,
    Ready
}

public class Field
{
    public int Id { get; set; }
    public FieldState State { get; set; } = FieldState.Empty;
    public DateTime? PlantedAt { get; set; }
    public TimeSpan GrowTime { get; set; } = TimeSpan.FromSeconds(30);

    public double ProgressSeconds
    {
        get
        {
            if (State != FieldState.Growing || PlantedAt == null) return 0;
            var elapsed = DateTime.UtcNow - PlantedAt.Value;
            return Math.Min(GrowTime.TotalSeconds, Math.Max(0, elapsed.TotalSeconds));
        }
    }

    public int ProgressPercent => (int)Math.Floor((ProgressSeconds / GrowTime.TotalSeconds) * 100);

    public void Plant()
    {
        State = FieldState.Growing;
        PlantedAt = DateTime.UtcNow;
    }

    public void UpdateTick()
    {
        if (State != FieldState.Growing || PlantedAt == null) return;
        var elapsed = DateTime.UtcNow - PlantedAt.Value;
        if (elapsed >= GrowTime)
        {
            State = FieldState.Ready;
            PlantedAt = null;
        }
    }

    public void Clear()
    {
        State = FieldState.Empty;
        PlantedAt = null;
    }
}
