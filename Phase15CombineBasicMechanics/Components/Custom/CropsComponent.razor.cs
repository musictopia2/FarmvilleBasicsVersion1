namespace Phase15CombineBasicMechanics.Components.Custom;
public partial class CropsComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    private EnumItemType? _selectedItem;
    private void SelectCrop(EnumItemType crop)
    {
        _selectedItem = crop;
    }
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    void Plant(CropInstance c)
    {
        if (_selectedItem is null)
        {
            return;
        }
        state.Plant(c, _selectedItem.Value);
    }
    void Harvest(CropInstance c)
    {
        state.Harvest(c);
    }
    private static string ReadyText(CropInstance c) => $"Ready In {c.ReadyTime!.Value.GetTimeString}";
    private bool CanPlant(CropInstance c)
    {
        if (_selectedItem is null)
        {
            return false;
        }
        return state.CanPlant(c, _selectedItem.Value);
    }
    private static string DisplayName(int item) => $"{EnumItemType.FromValue(item).Words}:";
    private static string GrowingText(CropInstance c) => $"Growing 2 {c.Crop!.Value.Words}";
    private string StartText
    {
        get
        {
            if (_selectedItem is null)
            {
                return "Empty";
            }
            return $"Plant {_selectedItem.Value.Words}";
        }
    }
    private string HarvestText(CropInstance c) => $"Harvest {c.Crop!.Value.Words}";
}