namespace Phase12MultipleHabitats.Components.Custom;
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
    void Plant(Habitat h)
    {
        if (_selectedCrop is null)
        {
            return;
        }
        state.Plant(h, _selectedCrop.Value);
    }
    void Harvest(Habitat h)
    {
        state.Harvest(h);
    }
    private static string ReadyText(Habitat h) => $"Ready In {h.ReadyTime!.Value.GetTimeString}";
    private bool CanPlant(Habitat h)
    {
        if (_selectedCrop is null)
        {
            return false;
        }
        return state.CanPlant(h, _selectedCrop.Value);
    }
    private static string DisplayName(int item) => $"{EnumCropType.FromValue(item).Words}:";
    private static string GrowingText(Habitat h) => $"Growing 2 {h.Crop!.Value.Words}";
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
    private static string HarvestText(Habitat h) => $"Harvest {h.Crop!.Value.Words}";
}