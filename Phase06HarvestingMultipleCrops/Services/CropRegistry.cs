namespace Phase06HarvestingMultipleCrops.Services;
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
            Item = EnumCropType.Wheat,
            Duration = TimeSpan.FromSeconds(30)
        });
        _crops.Add(new CropModel
        {
            Item = EnumCropType.Corn,
            Duration = TimeSpan.FromMinutes(2)
        });
    }
    public CropModel GetByName(EnumCropType item)
        => _crops.Single(r => r.Item == item);
}