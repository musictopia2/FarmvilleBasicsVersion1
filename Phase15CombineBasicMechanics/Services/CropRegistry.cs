
namespace Phase15CombineBasicMechanics.Services;
public class CropRegistry
{
    private readonly BasicList<CropModel> _crops = [];
    public IReadOnlyList<CropModel> All => _crops;
    public CropRegistry()
    {
        LoadHardCodedCrops();
    }
    private void LoadHardCodedCrops()
    {
        _crops.Add(new CropModel
        {
            Item = EnumItemType.Wheat,
            Duration = TimeSpan.FromSeconds(10)
        });
        _crops.Add(new CropModel
        {
            Item = EnumItemType.Corn,
            Duration = TimeSpan.FromSeconds(20)
        });
        _crops.Add(new CropModel
        {
            Item = EnumItemType.Honey,
            Duration = TimeSpan.FromSeconds(40)
        });
        _crops.Add(new CropModel
        {
            Item = EnumItemType.Shrimp,
            Duration = TimeSpan.FromSeconds(20)
        });
       
    }
    public CropModel GetByName(EnumItemType item)
        => _crops.Single(r => r.Item == item);
}