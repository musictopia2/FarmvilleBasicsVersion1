
namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Worksites;
public class BasicWorksitePolicy : IWorksitePolicy
{
    Task<bool> IWorksitePolicy.CanLockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        return Task.FromResult(false);
    }

    Task<bool> IWorksitePolicy.CanUnlockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        return Task.FromResult(false);
    }

    Task<WorksiteState> IWorksitePolicy.LockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        throw new NotImplementedException();
    }

    Task<WorksiteState> IWorksitePolicy.UnlockWorksiteAsync(BasicList<WorksiteState> list, string name)
    {
        throw new NotImplementedException();
    }
}