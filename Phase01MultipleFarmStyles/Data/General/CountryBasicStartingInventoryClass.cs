namespace Phase01MultipleFarmStyles.Data.General;
public class CountryBasicStartingInventoryClass : IStartingInventoryProvider
{
    Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync()
    {
        var dict = new Dictionary<string, int>
        {
            [CountryItemList.Wheat] = 6,
            [CountryItemList.Corn] = 6,
            [CountryItemList.Shrimp] = 6,
            [CountryItemList.Honey] = 6
        };
        return Task.FromResult(dict);
    }
}