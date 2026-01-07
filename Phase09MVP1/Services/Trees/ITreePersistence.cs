namespace Phase09MVP1.Services.Trees;
public interface ITreePersistence
{
    Task SaveTreesAsync(BasicList<TreeAutoResumeModel> trees);
}