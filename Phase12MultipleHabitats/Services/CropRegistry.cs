namespace Phase12MultipleHabitats.Services;
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
            Item = EnumCropType.Honey,
            Duration = TimeSpan.FromMinutes(1)
        });
        _crops.Add(new CropModel
        {
            Item = EnumCropType.Shrimp,
            Duration = TimeSpan.FromSeconds(20)
        });
    }
    public CropModel GetByName(EnumCropType item)
        => _crops.Single(r => r.Item == item);
}