namespace Phase06Autoresume.Services.Trees;
public interface ITreeFactory
{
    TreeServicesContext GetTreeServices(PlayerState player);
}