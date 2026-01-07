namespace Phase18SampleUpgrades.Data.Workers;
public class WorkerPolicy : IWorkerPolicy
{
    private int _maxUnlocks = 2;
    private int _currentUnlocks = 0;
    private int _currentLocks = 0;
    private int _maxLocks = 1; //can only lock one worker.
    private readonly Lock _lock = new();
    private WorkerState? GetWorker(BasicList<WorkerState> list, string name) => list.SingleOrDefault(x => x.Name == name);
    Task<bool> IWorkerPolicy.CanUnlockWorkerAsync(BasicList<WorksiteState> worksites, BasicList<WorkerState> workers, string name)
    {
        var worker = GetWorker(workers, name);
        if (worker is null)
        {
            return Task.FromResult(false);
        }
        if (worker.Unlocked)
        {
            return Task.FromResult(false);
        }
        if (_currentUnlocks >= _maxUnlocks)
        {
            return Task.FromResult(false);
        }
        if (name == WorkerListClass.Bob)
        {
            var site = worksites.Single(x => x.Name == WorksiteListClass.Pond);
            return Task.FromResult(site.Unlocked);
        }
        
        return Task.FromResult(true);
    }
    async Task IWorkerPolicy.UnlockWorkerAsync(BasicList<WorksiteState> worksites, BasicList<WorkerState> workers, string name)
    {
        lock (_lock)
        {
            var worker = GetWorker(workers, name);
            if (worker is null)
            {
                return;
            }
            _currentUnlocks++;
            worker.Unlocked = true;
        }
    }

    Task<bool> IWorkerPolicy.CanLockWorkerAsync(BasicList<WorksiteState> worksites, BasicList<WorkerState> workers, string name)
    {
        var worker = GetWorker(workers, name);

        if (worker is null)
        {
            return Task.FromResult(false);
        }
        if (worker.Unlocked == false)
        {
            return Task.FromResult(false);
        }
        if (worker.Name == WorkerListClass.Toby)
        {
            return Task.FromResult(false); //cannot lock whoever came with it.
        }
        if (_currentLocks >= _maxLocks)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
    async Task IWorkerPolicy.LockWorkerAsync(BasicList<WorksiteState> worksites, BasicList<WorkerState> workers, string name)
    {
        lock (_lock)
        {
            var worker = GetWorker(workers, name);
            if (worker is null)
            {
                return;
            }
            _currentLocks++;
            worker.Unlocked = false;
        }
    }   
}