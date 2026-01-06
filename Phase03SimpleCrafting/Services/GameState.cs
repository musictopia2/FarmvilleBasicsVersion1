namespace Phase03SimpleCrafting.Services;
public class GameState : IGameTimer
{
    //eventually needs to think about inventory management system.
    public int Wheat { get; private set; } = 13;
    public int Corn { get; private set; } = 7;
    public int Flour { get; set; }
    public int Sugar { get; set; }
    public object Lock = new();
    public BasicList<Windmill> WindmillQueue { get; private set; } = [];
    private void Consume(EnumJobType job)
    {
        if (job == EnumJobType.Flour)
        {
            Wheat -= 3;
        }
        if (job == EnumJobType.Sugar)
        {
            Corn -= 2;
        }
    }
    public bool CanCraft(EnumJobType job)
    {
        lock (Lock)
        {
            if (PrivateHasRequired(job) == false)
            {
                return false;
            }
            var queued = WindmillQueue.Count(j => j.State == EnumJobState.Active || j.State == EnumJobState.Waiting);
            return queued < 2;
        }
    }
    private bool PrivateHasRequired(EnumJobType job) =>
        job switch
        {
            EnumJobType.Flour => Wheat >= 3,
            EnumJobType.Sugar => Corn >= 2,
            _ => false
        };

    public void StartWindmillJob(EnumJobType job)
    {
        if (CanCraft(job) == false)
        {
            throw new CustomBasicException("Unable to craft.  Should had ran the CanCraft first");
        }
        Consume(job);
        CraftingJob craft = new(job);
        Windmill wind = new(craft);
        WindmillQueue.Add(wind);
    }

    void IGameTimer.Tick()
    {
        // Windmill job handling
        // If no active job, start the next waiting job if any and barn capacity allows
        var active = WindmillQueue.FirstOrDefault(j => j.State == EnumJobState.Active);
        if (active == null)
        {
            var next = WindmillQueue.FirstOrDefault(j => j.State == EnumJobState.Waiting);
            next?.Start(); //i think will go to the next one automatically (?)
        }

        // Process active job completion
        active = WindmillQueue.FirstOrDefault(j => j.State == EnumJobState.Active);
        if (active != null)
        {
            if (DateTime.Now - active.Job.StartedAt >= active.Job.CraftTime)
            {
                active.Complete();
                // Add 1 flour to barn
                if (active.Job.Type == EnumJobType.Flour)
                {
                    Flour++;
                }
                if (active.Job.Type == EnumJobType.Sugar)
                {
                    Sugar++;
                }
            }
        }

        // prune completed jobs older than a minute
        // for now.
        WindmillQueue.RemoveAllAndObtain(j => j.State == EnumJobState.Completed && (DateTime.Now - (j.Job.CompletedAt ?? DateTime.Now)) > TimeSpan.FromMinutes(1));
    }
}