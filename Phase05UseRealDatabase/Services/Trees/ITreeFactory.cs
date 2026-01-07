namespace Phase05UseRealDatabase.Services.Trees;
public interface ITreeFactory
{
    TreeServicesContext GetTreeServices(PlayerState player);
}