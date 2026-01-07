namespace Phase11SingleHabitat.Components.Custom;
public partial class MainComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    void Plant(Habitat f)
    {
        state.Plant(f);
    }

    void Harvest(Habitat f)
    {
        state.Harvest(f);
    }
    private static string ReadyText(Habitat f) => $"Ready In {f.ReadyTime!.Value.GetTimeString}";
    private bool CanPlant(Habitat f) => state.CanPlant(f);

}