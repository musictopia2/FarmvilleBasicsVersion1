using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase01.Services;

public class GameState
{
    public List<Field> Fields { get; private set; } = new List<Field>();
    public int SiloWheat { get; private set; }
    public int BarnFlour { get; private set; }
    public List<WindmillJob> WindmillQueue { get; private set; } = new List<WindmillJob>();
    //was 70 and 70 but reduced it to begin with.
    public int SiloCapacity { get; } = 20;
    public int BarnCapacity { get; } = 20;

    public object Lock = new object();

    public GameState()
    {
        // Initialize 8 fields
        for (int i = 0; i < 8; i++)
        {
            Fields.Add(new Field { Id = i });
        }

        // Start player with 8 wheat
        SiloWheat = 0;
        BarnFlour = 0;
    }

    // Plant a field if possible
    public bool CanPlant(Field field)
    {
        lock (Lock)
        {
            if (field == null || field.State != FieldState.Empty)
                return false;

            // Normal case: have at least 1 wheat
            if (SiloWheat > 0)
                return true;

            // Special rule: if player has 0 wheat but no fields are currently growing,
            // allow planting one to avoid locking the game.
            if (SiloWheat == 0)
            {
                var anyGrowing = Fields.Any(f => f.State == FieldState.Growing);
                return !anyGrowing;
            }

            return false;
        }
    }

    public bool Plant(Field field)
    {
        lock (Lock)
        {
            if (!CanPlant(field)) return false;

            // Deduct wheat only if available; do not go negative. If SiloWheat == 0
            // and CanPlant allowed due to no growing fields, permit the plant without deduction.
            if (SiloWheat > 0)
            {
                SiloWheat -= 1;
            }

            field.Plant();
            return true;
        }
    }

    public bool CanHarvest(Field field)
    {
        lock (Lock)
        {
            return field != null && field.State == FieldState.Ready && SiloWheat < SiloCapacity;
        }
    }

    public bool Harvest(Field field)
    {
        lock (Lock)
        {
            if (!CanHarvest(field)) return false;
            // Harvest gives +2 wheat
            SiloWheat += 2;
            if (SiloWheat > SiloCapacity) SiloWheat = SiloCapacity;
            field.Clear();
            return true;
        }
    }

    // Called by timer each second
    public void Tick()
    {
        lock (Lock)
        {
            foreach (var f in Fields)
            {
                f.UpdateTick();
            }

            // Windmill job handling
            // If no active job, start the next waiting job if any and barn capacity allows
            var active = WindmillQueue.FirstOrDefault(j => j.State == JobState.Active);
            if (active == null)
            {
                var next = WindmillQueue.FirstOrDefault(j => j.State == JobState.Waiting);
                if (next != null)
                {
                    // ensure barn has space for resulting flour
                    if (BarnFlour < BarnCapacity)
                    {
                        next.Start();
                    }
                }
            }

            // Process active job completion
            active = WindmillQueue.FirstOrDefault(j => j.State == JobState.Active);
            if (active != null)
            {
                if (DateTime.UtcNow - active.StartedAt >= active.CraftTime)
                {
                    active.Complete();
                    // Add 1 flour to barn
                    BarnFlour += 1;
                    if (BarnFlour > BarnCapacity) BarnFlour = BarnCapacity;
                }
            }

            // prune completed jobs older than a minute
            WindmillQueue.RemoveAll(j => j.State == JobState.Completed && (DateTime.UtcNow - (j.CompletedAt ?? DateTime.UtcNow)) > TimeSpan.FromMinutes(1));
        }
    }

    // Windmill controls
    public bool CanStartWindmillJob()
    {
        lock (Lock)
        {
            // Need 3 wheat and barn has space and queue < 2 jobs
            if (SiloWheat < 3) return false;
            if (BarnFlour >= BarnCapacity) return false;
            var queued = WindmillQueue.Count(j => j.State == JobState.Active || j.State == JobState.Waiting);
            return queued < 2;
        }
    }

    public bool StartWindmillJob()
    {
        lock (Lock)
        {
            if (!CanStartWindmillJob())
            {
                return false;
            }

            SiloWheat -= 3;
            var job = new WindmillJob();
            WindmillQueue.Add(job);
            return true;
        }
    }
}
