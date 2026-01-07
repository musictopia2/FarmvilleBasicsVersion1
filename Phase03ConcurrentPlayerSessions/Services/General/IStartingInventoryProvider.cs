namespace Phase03ConcurrentPlayerSessions.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync(PlayerState player);
}