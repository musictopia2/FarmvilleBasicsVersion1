namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync();
}