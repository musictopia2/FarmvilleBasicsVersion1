namespace Phase18SampleUpgrades.Services.Trees;
public interface ITreePolicy
{
    Task<bool> CanUnlockTreeAsync(BasicList<TreeState> list, string name);
    Task<TreeState> UnlockTreeAsync(BasicList<TreeState> list, string name);
    Task<bool> CanLockTreeAsync(BasicList<TreeState> list, string name);
    Task<TreeState> LockTreeAsync(BasicList<TreeState> list, string name);
}