namespace Phase06Autoresume.Services.Trees;
public interface ITreePersistence
{
    Task SaveTreesAsync(BasicList<TreeAutoResumeModel> trees);
}