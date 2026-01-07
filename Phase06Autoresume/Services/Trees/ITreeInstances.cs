namespace Phase06Autoresume.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeAutoResumeModel>> GetTreeInstancesAsync();
}