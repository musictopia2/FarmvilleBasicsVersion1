
namespace Phase09MVP1.Services.Trees;
public class TreeGatherOneByOnePolicy : ITreeGatheringPolicy
{
    Task<bool> ITreeGatheringPolicy.CollectAllAsync()
    {
        return Task.FromResult(false);
    }
}