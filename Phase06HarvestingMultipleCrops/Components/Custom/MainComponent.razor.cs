namespace Phase06HarvestingMultipleCrops.Components.Custom;
public partial class MainComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    private EnumCropType? _selectedCrop;
    private void SelectCrop(EnumCropType crop)
    {
        _selectedCrop = crop;
    }
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    void Plant(Field f)
    {
        if (_selectedCrop is null)
        {
            return;
        }
        state.Plant(f, _selectedCrop.Value);
    }
    void Harvest(Field f)
    {
        state.Harvest(f);
    }
    private static string ReadyText(Field f) => $"Ready In {f.ReadyTime!.Value.GetTimeString}";
    private bool CanPlant(Field f)
    {
        if (_selectedCrop is null)
        {
            return false;
        }
        return state.CanPlant(f, _selectedCrop.Value);
    }
    private static string DisplayName(int item) => $"{EnumCropType.FromValue(item).Words}:";
    private static string GrowingText(Field f) => $"Growing 2 {f.Crop!.Value.Words}";
    private string StartText
    {
        get
        {
            if (_selectedCrop is null)
            {
                return "Empty";
            }
            return $"Plant {_selectedCrop.Value.Words}";
        }
    }
    private string HarvestText(Field f) => $"Harvest {f.Crop!.Value.Words}";
}