namespace Phase09MVP1.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync(FarmKey farm);
}