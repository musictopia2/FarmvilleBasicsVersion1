namespace Phase04CollectionProcesses.Components.Custom;
public partial class CropsComponent
{
    private string? _selectedItem;
    private bool _hasUnlockedCrops = false;
    private void SelectCrop(string id)
    {
        _selectedItem = id;
    }
    private BasicList<string> _crops = [];
    protected override void OnInitialized()
    {
        base.OnInitialized();
        _crops = CropManager.UnlockedRecipes;
        _hasUnlockedCrops = CropManager.HasUnlockedCrops;
    }
    void Plant(Guid id)
    {
        if (_selectedItem is null)
        {
            return;
        }
        CropManager.Plant(id, _selectedItem);
    }
    void Harvest(Guid id)
    {
        CropManager.Harvest(id);
    }
    private string ReadyText(Guid id) => $"Ready In {CropManager.GetTimeLeft(id)}";
    private bool CanPlant(Guid id)
    {
        if (_selectedItem is null)
        {
            return false;
        }
        return CropManager.CanPlant(id, _selectedItem);
    }
    private EnumCropState GetState(Guid id) => CropManager.GetCropState(id);
    private string GrowingText(Guid id) => $"Growing 2 {CropManager.GetCropName(id)}";
    private string StartText
    {
        get
        {
            if (_selectedItem is null)
            {
                return "Empty";
            }
            return $"Plant {_selectedItem}";
        }
    }
    private string HarvestText(Guid id) => $"Harvest {CropManager.GetCropName(id)}";
}