namespace Phase01MultipleFarmStyles.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeDataModel>> GetTreeInstancesAsync();
}