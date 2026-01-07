namespace Phase06Autoresume.Services.Worksites;
public class WorksiteManager(
    Inventory inventory
    )
{
    private IWorksiteProgressPolicy? _worksiteProgressPolicy;
    private EnumWorksiteCollectionMode _worksiteCollectionMode;
    private IWorksiteCollectionPolicy? _worksiteCollectionPolicy;
    private IWorksitePersistence _worksitePersistence = null!;
    private IWorkerPolicy? _workerPolicy;
    private readonly BasicList<WorksiteInstance> _worksites = [];
    private BasicList<WorkerDataModel> _workerStates = [];
    private BasicList<WorkerRecipe> _allWorkers = [];
    public event Action? OnWorksitesUpdated;
    public event Action? OnWorkersUpdated; //not sure if i need (but may need it).
    private bool _needsSaving;
    private DateTime _lastSave = DateTime.MinValue;
    private Lock _lock = new();

    public BasicList<WorkerRecipe> GetUnlockedWorkers
    {
        get
        {
            var unlockedNames = _workerStates.Where(x => x.Unlocked).Select(x => x.Name).ToBasicList();
            return _allWorkers.Where(x => unlockedNames.Contains(x.WorkerName)).ToBasicList();
        }
    }
    private WorksiteInstance GetWorksiteByLocation(string location)
    {
        var worksite = _worksites.SingleOrDefault(t => t.Location == location) ?? throw new CustomBasicException($"Worksite with location {location} not found.");
        return worksite;
    }
    private BasicList<WorkerState> GetAllWorkers
    {
        get
        {
            if (_workerStates.Count == 0)
            {
                return []; //for now.
            }
            BasicList<WorkerState> output = [];
            _allWorkers.ForEach(w =>
            {
                WorkerDataModel data = _workerStates.Single(x => x.Name == w.WorkerName);
                output.Add(new WorkerState()
                {
                    Name = w.WorkerName,
                    Status = w.WorkerStatus,
                    Unlocked = data.Unlocked
                });
            });
            return output;
        }
    }
    public async Task<bool> CanUnlockWorkerAsync(string name)
    {
        if (_workerPolicy is null)
        {
            return false;
        }
        var workers = GetAllWorkers;
        var sites = GetAllWorksites;
        var policy = await _workerPolicy.CanUnlockWorkerAsync(sites, workers, name);
        return policy;
    }

    public async Task UnlockWorkerAsync(string name)
    {
        var workers = GetAllWorkers;
        var sites = GetAllWorksites;
        await _workerPolicy!.UnlockWorkerAsync(sites, workers, name);
        UpdateWorkers(workers);
        OnWorkersUpdated?.Invoke();
    }

    public async Task<bool> CanLockWorkerAsync(string name)
    {
        if (_workerPolicy is null)
        {
            return false;
        }
        var workers = GetAllWorkers;
        var sites = GetAllWorksites;
        var policy = await _workerPolicy.CanLockWorkerAsync(sites, workers, name);
        return policy;
    }
    public async Task LockWorkerAsync(string name)
    {
        var workers = GetAllWorkers;
        var sites = GetAllWorksites;
        await _workerPolicy!.LockWorkerAsync(sites, workers, name);
        UpdateWorkers(workers);
        OnWorkersUpdated?.Invoke();
    }
    private void UpdateWorkers(BasicList<WorkerState> list)
    {
        foreach (var item in list)
        {
            WorkerDataModel worker = _workerStates.Single(x => x.Name == item.Name);
            worker.Unlocked = item.Unlocked;
        }
    }
    public void AddWorker(string location, WorkerRecipe worker)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        instance.AddWorker(worker);
        _needsSaving = true;
    }
    public void RemoveWorker(string location, WorkerRecipe worker)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        instance.RemoveWorker(worker);
        _needsSaving = true;
    }
    public bool CanStartJob(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.CanStartJob(inventory);
    }
    public void StartJob(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        instance.StartJob(inventory);
        _needsSaving = true;
    }
    public bool CanCollectRewards(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.CanCollectRewards;
    }
    public BasicList<ItemAmount> GetRewards(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.GetRewards();
    }
    public void CollectAllRewards(string location, BasicList<ItemAmount> rewards)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        CollectAllRewards(instance, rewards);
    }
    public void CollectSingleReward(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        ItemAmount reward = instance.GetFirstReward;
        inventory.Add(reward.Item, reward.Amount);
        _needsSaving = true;
    }

    private void CollectAllRewards(WorksiteInstance instance, BasicList<ItemAmount> rewards)
    {
        rewards.ForEach(reward =>
        {
            inventory.Add(reward.Item, reward.Amount);
        });
        instance.CollectAllRewards();
        _needsSaving = true;
    }
    public BasicList<WorkerRecipe> GetWorkers(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.Workers;
    }
    public EnumWorksiteState GetStatus(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.Status;
    }
    public string GetDurationText(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return $"{instance.StartText} ({instance.Duration.GetTimeString})";
    }
    public string GetProgressText(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return $"Come back in {instance.ReadyTime!.Value.GetTimeString}";
    }
    public BasicList<WorksiteRewardPreview> GetPreview(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.GetPreview();
    }
    public BasicList<ItemAmount> SuppliesNeeded(string location)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        return instance.SuppliesNeeded;
    }
    public BasicList<string> GetUnlockedWorksites()
    {
        BasicList<string> output = [];
        _worksites.ForConditionalItems(x => x.Unlocked, t =>
        {
            output.Add(t.Location);
        });
        return output;
    }
    private BasicList<WorksiteState> GetAllWorksites
    {
        get
        {
            BasicList<WorksiteState> output = [];
            _worksites.ForEach(t =>
            {
                output.Add(new()
                {
                    Name = t.Location,
                    Unlocked = t.Unlocked,
                    State = t.Status
                });
            });
            return output;
        }
    }
    public async Task<bool> CanUnlockWorksiteAsync(string name)
    {
        if (_worksiteProgressPolicy is null)
        {
            return false;
        }
        var list = GetAllWorksites;
        var policy = await _worksiteProgressPolicy.CanUnlockWorksiteAsync(list, name);
        return policy;
    }
    public async Task UnlockWorksiteAsync(string name)
    {
        var list = GetAllWorksites;
        var policy = await _worksiteProgressPolicy!.UnlockWorksiteAsync(list, name);
        UpdateWorksiteInstance(policy);
    }
    public async Task<bool> CanLockWorksiteAsync(string name)
    {
        if (_worksiteProgressPolicy is null)
        {
            return false;
        }
        var list = GetAllWorksites;
        var policy = await _worksiteProgressPolicy.CanLockWorksiteAsync(list, name);
        return policy;
    }
    public async Task LockWorksiteAsync(string name)
    {
        var list = GetAllWorksites;
        var policy = await _worksiteProgressPolicy!.LockWorksiteAsync(list, name);
        UpdateWorksiteInstance(policy);
    }
    private void UpdateWorksiteInstance(WorksiteState summary)
    {
        var worksite = _worksites.Single(x => x.Location == summary.Name);
        worksite.Unlocked = summary.Unlocked;
        OnWorksitesUpdated?.Invoke();
        _needsSaving = true;
    }
    public async Task<EnumWorksiteCollectionMode> GetCollectionModeAsync()
    {
        _worksiteCollectionMode = await _worksiteCollectionPolicy!.GetCollectionModeAsync();
        return _worksiteCollectionMode;
    }
    public async Task SetStyleContextAsync(WorksiteServicesContext worksiteContext,
        WorkerServicesContext workerContext)
    {
        if (_worksitePersistence != null)
        {
            throw new InvalidOperationException("Persistance Already set");
        }
        _worksitePersistence = worksiteContext.WorksitePersistence;
        BasicList<WorksiteRecipe> recipes = await worksiteContext.WorksiteRegistry.GetWorksitesAsync();
        _worksiteProgressPolicy = worksiteContext.WorksiteProgressPolicy;
        _worksiteCollectionPolicy = worksiteContext.WorksiteCollectionPolicy;
        _worksiteCollectionMode = await _worksiteCollectionPolicy.GetCollectionModeAsync();
        _workerPolicy = workerContext.WorkerPolicy;
        _worksites.Clear();
        _workerStates = await workerContext.WorkerInstances.GetWorkerInstancesAsync();
        var ours = await worksiteContext.WorksiteInstances.GetWorksiteInstancesAsync();
        _allWorkers = await workerContext.WorkerRegistry.GetWorkersAsync();
        foreach (var item in ours)
        {
            WorksiteRecipe recipe = recipes.Single(x => x.Location == item.Name);
            WorksiteInstance instance = new(recipe);
            instance.Load(item);
            foreach (var tempWorker in item.Workers)
            {
                WorkerRecipe reals = _allWorkers.Single(x => x.WorkerName == tempWorker.WorkerName);
                reals.WorkerStatus = tempWorker.WorkerStatus;
                reals.CurrentLocation = tempWorker.CurrentLocation;
                instance.AddWorkerAfterLoading(reals);
            }
            _worksites.Add(instance);
        }
    }
    public void StoreRewards(string location, BasicList<ItemAmount> rewards)
    {
        var worksite = _worksites.Single(x => x.Location == location);
        worksite.StoreRewards(rewards);
        _needsSaving = true;
    }

    // Tick method called by game timer
    public async Task UpdateTickAsync()
    {
        _worksites.ForConditionalItems(x => x.Unlocked && x.Status != EnumWorksiteState.None, worksite =>
        {
            worksite.UpdateTick();
            if (worksite.NeedsSaving)
            {
                _needsSaving = true;
            }
            //may be automated now.
            if (worksite.Status == EnumWorksiteState.Collecting && _worksiteCollectionMode == EnumWorksiteCollectionMode.Automated)
            {
                var rewards = worksite.GetRewards();
                CollectAllRewards(worksite, rewards);
            }
        });
        await SaveWorksitesAsync();
    }

    private async Task SaveWorksitesAsync()
    {
        bool doSave = false;
        lock (_lock)
        {
            if (_needsSaving && DateTime.Now - _lastSave > GameRegistry.SaveThrottle)
            {
                _needsSaving = false;
                doSave = true;
                _lastSave = DateTime.Now;
            }
        }
        if (doSave)
        {
            BasicList<WorksiteAutoResumeModel> list = _worksites
             .Select(worksite => worksite.GetWorksiteForSaving)
             .ToBasicList();
            await _worksitePersistence.SaveWorksitesAsync(list);
        }
    }
}