
namespace Phase07Images.Services.Trees;
public class TreeGatherAllPolicy : ITreeGatheringPolicy
{
    Task<bool> ITreeGatheringPolicy.CollectAllAsync()
    {
        return Task.FromResult(true);
    }
}