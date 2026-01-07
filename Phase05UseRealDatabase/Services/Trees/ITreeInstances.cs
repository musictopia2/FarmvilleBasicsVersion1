namespace Phase05UseRealDatabase.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeDataModel>> GetTreeInstancesAsync();
}