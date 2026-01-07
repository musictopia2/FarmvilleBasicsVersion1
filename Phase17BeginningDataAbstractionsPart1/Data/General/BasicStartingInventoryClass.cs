namespace Phase17BeginningDataAbstractionsPart1.Data.General;
public class BasicStartingInventoryClass : IStartingInventoryProvider
{
    Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync()
    {
        var dict = new Dictionary<string, int>
        {
            [ItemList.Wheat] = 60,
            [ItemList.Corn] = 6,
            [ItemList.Shrimp] = 6,
            [ItemList.HoneyComb] = 6
        };
        return Task.FromResult(dict);
    }
}