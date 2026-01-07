namespace Phase05UseRealDatabase.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync(PlayerState player);
}