namespace Phase05HarvestingSingleCrops.Components.Custom;
public partial class MainComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    void Plant(Field f)
    {
        state.Plant(f);
    }

    void Harvest(Field f)
    {
        state.Harvest(f);
    }
    private static string ReadyText(Field f) => $"Ready In {f.ReadyTime!.Value.GetTimeString}";
    private bool CanPlant(Field f) => state.CanPlant(f);
   
}