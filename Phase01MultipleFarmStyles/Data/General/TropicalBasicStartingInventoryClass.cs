namespace Phase01MultipleFarmStyles.Data.General;
public class TropicalBasicStartingInventoryClass : IStartingInventoryProvider
{
    Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync()
    {
        var dict = new Dictionary<string, int>
        {
            [TropicalItemList.Pineapples] = 10,
            [TropicalItemList.Rice] = 10,
            [TropicalItemList.Flowers] = 10,
            [TropicalItemList.SugarCane] = 10
        };
        return Task.FromResult(dict);
    }
}