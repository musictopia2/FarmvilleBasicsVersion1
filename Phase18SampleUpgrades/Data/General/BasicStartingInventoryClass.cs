namespace Phase18SampleUpgrades.Data.General;
public class BasicStartingInventoryClass : IStartingInventoryProvider
{
    Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync()
    {
        var dict = new Dictionary<string, int>
        {
            [ItemList.Wheat] = 60,
            [ItemList.Corn] = 6,
            [ItemList.Shrimp] = 6,
            [ItemList.Honey] = 6
        };
        return Task.FromResult(dict);
    }
}