namespace Phase03ConcurrentPlayerSessions.Services.Trees;
public interface ITreeFactory
{
    TreeServicesContext GetTreeServices(PlayerState player);
}