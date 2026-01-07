namespace Phase06Autoresume.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync(PlayerState player);
}