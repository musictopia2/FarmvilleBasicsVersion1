namespace Phase17BeginningDataAbstractionsPart1.Services.General;
public interface IStartingInventoryProvider
{
    Task<Dictionary<string, int>> GetStartingInventoryAsync();
}