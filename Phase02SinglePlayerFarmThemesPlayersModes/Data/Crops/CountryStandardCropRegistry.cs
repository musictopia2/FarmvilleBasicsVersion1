namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Crops;
public class CountryStandardCropRegistry : ICropRegistry
{
    //if i wanted do something with player state can do but won't

    Task<BasicList<CropRecipe>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropRecipe> output = [];
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Wheat,
            Duration = TimeSpan.FromSeconds(30)
        });
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Corn,
            Duration = TimeSpan.FromMinutes(2)
        });
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Honey,
            Duration = TimeSpan.FromMinutes(45)
        });
        output.Add(new CropRecipe
        {
            Item = CountryItemList.Shrimp,
            Duration = TimeSpan.FromMinutes(10)
        });
        return Task.FromResult(output);
    }

}