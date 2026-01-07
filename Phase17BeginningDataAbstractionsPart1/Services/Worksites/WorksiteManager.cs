namespace Phase17BeginningDataAbstractionsPart1.Services.Worksites;
public class WorksiteManager(IWorksiteRegistry worksiteRegistry,
    IWorksiteInstances instances,
    IWorkerRegistry workerRegistry,
    Inventory inventory
    )
{
    private readonly BasicList<WorksiteInstance> _worksites = [];
    private BasicList<WorkerModel> _workers = [];
    public BasicList<WorkerModel> GetAllWorkers => _workers.ToBasicList();
    private WorksiteInstance GetWorksiteByLocation(string location)
    {
        var worksite = _worksites.SingleOrDefault(t => t.Location == location) ?? throw new CustomBasicException($"Worksite with location {location} not found.");
        return worksite;
    }
    public void AddWorker(string location, WorkerModel worker)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        instance.AddWorker(worker);
    }
    public void RemoveWorker(string location, WorkerModel worker)
    {
        WorksiteInstance instance = GetWorksiteByLocation(location);
        instance.RemoveWorker(worker);
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
        rewards.ForEach(reward =>
        {
            inventory.Add(reward.Item, reward.Amount);
        });
        instance.CollectAllRewards();
    }
    public BasicList<WorkerModel> GetWorkers(string location)
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
    public BasicList<string> GetAllWorksites()
    {
        BasicList<string> output = [];
        _worksites.ForEach(t =>
        {
            output.Add(t.Location);
        });
        return output;
    }
    public async Task PopulateWorksitesAsync()
    {
        BasicList<WorksiteRecipe> recipes = await worksiteRegistry.GetWorksitesAsync();
        var ours = await instances.GetWorksiteInstances();
        foreach (var item in ours)
        {
            WorksiteRecipe recipe = recipes.Single(x => x.Location == item);
            WorksiteInstance instance = new(recipe);
            _worksites.Add(instance);
        }
        _workers = await workerRegistry.GetWorkersAsync();


    }
    // Tick method called by game timer
    public void UpdateTick()
    {
        _worksites.ForEach(worksite => worksite.UpdateTick());
    }
}