namespace Phase01MultipleFarmStyles.Services.Worksites;
public interface IWorksitePolicy
{
    Task<bool> CanUnlockWorksiteAsync(BasicList<WorksiteState> list, string name);
    Task<WorksiteState> UnlockWorksiteAsync(BasicList<WorksiteState> list, string name);
    Task<bool> CanLockWorksiteAsync(BasicList<WorksiteState> list, string name);
    Task<WorksiteState> LockWorksiteAsync(BasicList<WorksiteState> list, string name);
}