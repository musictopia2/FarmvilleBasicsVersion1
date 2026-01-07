using Phase18SampleUpgrades.Data.General;

namespace Phase18SampleUpgrades.Data.Crops;
public class CropRegistry : ICropRegistry
{
    Task<BasicList<CropRecipe>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropRecipe> output = [];
        output.Add(new CropRecipe
        {
            Item = ItemList.Wheat,
            Duration = TimeSpan.FromSeconds(10)
        });
        output.Add(new CropRecipe
        {
            Item = ItemList.Corn,
            Duration = TimeSpan.FromSeconds(20)
        });
        output.Add(new CropRecipe
        {
            Item = ItemList.Honey,
            Duration = TimeSpan.FromSeconds(40)
        });
        output.Add(new CropRecipe
        {
            Item = ItemList.Shrimp,
            Duration = TimeSpan.FromSeconds(20)
        });
        return Task.FromResult(output);
    }
}