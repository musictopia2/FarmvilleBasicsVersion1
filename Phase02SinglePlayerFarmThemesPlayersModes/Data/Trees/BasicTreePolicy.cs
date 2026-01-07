namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Trees;
public class BasicTreePolicy : ITreePolicy
{
    Task<bool> ITreePolicy.CanLockTreeAsync(BasicList<TreeState> list, string name)
    {
        return Task.FromResult(false);
    }

    Task<bool> ITreePolicy.CanUnlockTreeAsync(BasicList<TreeState> list, string name)
    {
        return Task.FromResult(false);
    }

    Task<TreeState> ITreePolicy.LockTreeAsync(BasicList<TreeState> list, string name)
    {
        throw new NotImplementedException();
    }

    Task<TreeState> ITreePolicy.UnlockTreeAsync(BasicList<TreeState> list, string name)
    {
        throw new NotImplementedException();
    }
}