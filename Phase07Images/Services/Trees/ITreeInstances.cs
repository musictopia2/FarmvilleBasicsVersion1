namespace Phase07Images.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeAutoResumeModel>> GetTreeInstancesAsync();
}