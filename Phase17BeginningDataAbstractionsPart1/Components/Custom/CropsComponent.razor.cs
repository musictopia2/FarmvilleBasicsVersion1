namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class CropsComponent(CropManager manager)
{
    private string? _selectedItem;
    private void SelectCrop(string id)
    {
        _selectedItem = id;
    }
    private BasicList<CropModel> _crops = [];
    protected override void OnInitialized()
    {
        base.OnInitialized();
        _crops = manager.Recipes;
    }
    void Plant(Guid id)
    {
        if (_selectedItem is null)
        {
            return;
        }
        manager.Plant(id, _selectedItem);
    }
    void Harvest(Guid id)
    {
        manager.Harvest(id);
    }
    private string ReadyText(Guid id) => $"Ready In {manager.GetTimeLeft(id)}";
    private bool CanPlant(Guid id)
    {
        if (_selectedItem is null)
        {
            return false;
        }
        return manager.CanPlant(id, _selectedItem);
    }
    private EnumCropState GetState(Guid id) => manager.GetCropState(id);
    private string GrowingText(Guid id) => $"Growing 2 {manager.GetCropName(id)}";
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
    private string HarvestText(Guid id) => $"Harvest {manager.GetCropName(id)}";
}