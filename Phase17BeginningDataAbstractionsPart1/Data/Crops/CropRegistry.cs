using Phase17BeginningDataAbstractionsPart1.Data.General;

namespace Phase17BeginningDataAbstractionsPart1.Data.Crops;
public class CropRegistry : ICropRegistry
{
    Task<BasicList<CropModel>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropModel> output = [];
        output.Add(new CropModel
        {
            Item = ItemList.Wheat,
            Duration = TimeSpan.FromSeconds(10)
        });
        output.Add(new CropModel
        {
            Item = ItemList.Corn,
            Duration = TimeSpan.FromSeconds(20)
        });
        output.Add(new CropModel
        {
            Item = ItemList.HoneyComb,
            Duration = TimeSpan.FromSeconds(40)
        });
        output.Add(new CropModel
        {
            Item = ItemList.Shrimp,
            Duration = TimeSpan.FromSeconds(20)
        });
        return Task.FromResult(output);
    }
}