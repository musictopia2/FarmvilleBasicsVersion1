namespace Phase04CollectionProcesses.Services.Trees;
public interface ITreeFactory
{
    TreeServicesContext GetTreeServices(PlayerState player);
}