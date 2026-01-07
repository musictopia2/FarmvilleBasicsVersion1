namespace Phase03ConcurrentPlayerSessions.Services.General;
public interface IStartFarmRegistry
{
    Task<BasicList<PlayerState>> GetFarmsAsync(); 
}