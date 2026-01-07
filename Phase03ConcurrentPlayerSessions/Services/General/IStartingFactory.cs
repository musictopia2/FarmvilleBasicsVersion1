namespace Phase03ConcurrentPlayerSessions.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(PlayerState player);
}