using System;
using System.Collections.Generic;

namespace Phase01.Services;

public enum JobState
{
    Waiting,
    Active,
    Completed
}

public class WindmillJob
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public JobState State { get; set; } = JobState.Waiting;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public TimeSpan CraftTime { get; set; } = TimeSpan.FromSeconds(30);

    public double ProgressSeconds
    {
        get
        {
            if (State != JobState.Active) return 0;
            var elapsed = DateTime.UtcNow - StartedAt;
            return Math.Min(CraftTime.TotalSeconds, Math.Max(0, elapsed.TotalSeconds));
        }
    }

    public int ProgressPercent => (int)Math.Floor((ProgressSeconds / CraftTime.TotalSeconds) * 100);

    public void Start()
    {
        State = JobState.Active;
        StartedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        State = JobState.Completed;
        CompletedAt = DateTime.UtcNow;
    }
}
