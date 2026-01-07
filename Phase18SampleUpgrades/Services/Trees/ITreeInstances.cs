namespace Phase18SampleUpgrades.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeDataModel>> GetTreeInstancesAsync();
}