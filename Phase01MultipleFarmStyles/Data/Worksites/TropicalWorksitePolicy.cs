namespace Phase01MultipleFarmStyles.Data.Worksites;
public class TropicalWorksitePolicy : IWorksitePolicy
{
    private static WorksiteState? GetWorksite(BasicList<WorksiteState> list, string name) => list.SingleOrDefault(x => x.Name == name);
    private readonly Lock _lock = new();
    Task<bool> IWorksitePolicy.CanLockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        WorksiteState? w = GetWorksite(list, name);
        if (w is null)
        {
            return Task.FromResult(false); //does not even exist
        }
        return Task.FromResult(w.Unlocked);
    }
    Task<bool> IWorksitePolicy.CanUnlockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        WorksiteState? w = GetWorksite(list, name);
        if (w is null)
        {
            return Task.FromResult(false); //does not even exist
        }
        return Task.FromResult(w.Unlocked == false);
    }
    async Task<WorksiteState> IWorksitePolicy.LockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        lock (_lock)
        {
            WorksiteState? w = GetWorksite(list, name);
            CustomBasicException.ThrowIfNull(w);
            w.Unlocked = false;
            return w;
        }
    }
    async Task<WorksiteState> IWorksitePolicy.UnlockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        lock (_lock)
        {
            WorksiteState? w = GetWorksite(list, name);
            CustomBasicException.ThrowIfNull(w);
            w.Unlocked = true;
            return w;
        }
    }
}