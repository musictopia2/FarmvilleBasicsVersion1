namespace Phase07Images.Services.Trees;
public interface ITreePersistence
{
    Task SaveTreesAsync(BasicList<TreeAutoResumeModel> trees);
}