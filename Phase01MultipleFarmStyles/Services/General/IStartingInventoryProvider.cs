namespace Phase01MultipleFarmStyles.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync();
}