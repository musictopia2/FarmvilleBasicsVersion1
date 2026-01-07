namespace Phase01MultipleFarmStyles.Data.Crops;
public class TropicalCropRegistry : ICropRegistry
{
    Task<BasicList<CropRecipe>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropRecipe> output = [];
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.Pineapples,
            Duration = TimeSpan.FromSeconds(10)
        });
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.Rice,
            Duration = TimeSpan.FromSeconds(15)
        });
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.Flowers,
            Duration = TimeSpan.FromSeconds(20)
        });
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.SugarCane,
            Duration = TimeSpan.FromSeconds(30)
        });
        return Task.FromResult(output);
    }
}