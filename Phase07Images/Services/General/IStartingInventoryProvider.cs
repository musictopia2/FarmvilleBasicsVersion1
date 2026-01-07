namespace Phase07Images.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync(PlayerState player);
}