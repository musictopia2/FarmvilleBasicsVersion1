namespace Phase01MultipleFarmStyles.Data.Crops;
public class CountryCropRegistry : ICropRegistry
{
    Task<BasicList<CropRecipe>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropRecipe> output = [];
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Wheat,
            Duration = TimeSpan.FromSeconds(10)
        });
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Corn,
            Duration = TimeSpan.FromSeconds(20)
        });
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Honey,
            Duration = TimeSpan.FromSeconds(40)
        });
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Shrimp,
            Duration = TimeSpan.FromSeconds(20)
        });
        return Task.FromResult(output);
    }
}