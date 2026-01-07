namespace Phase03ConcurrentPlayerSessions.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeDataModel>> GetTreeInstancesAsync();
}