namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Crops;
public class TropicalStandardCropRegistry : ICropRegistry
{
    Task<BasicList<CropRecipe>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropRecipe> output = [];
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.Pineapple,
            Duration = TimeSpan.FromSeconds(30)
        });
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.Rice,
            Duration = TimeSpan.FromMinutes(1)
        });
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.Orchid,
            Duration = TimeSpan.FromMinutes(12)
        });
        output.Add(new CropRecipe
        {
            Item = TropicalItemList.SugarCane,
            Duration = TimeSpan.FromMinutes(15)
        });
        return Task.FromResult(output);
    }
}