namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<TreeDataModel>> GetTreeInstancesAsync();
}