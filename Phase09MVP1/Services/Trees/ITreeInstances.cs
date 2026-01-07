namespace Phase09MVP1.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeAutoResumeModel>> GetTreeInstancesAsync();
}