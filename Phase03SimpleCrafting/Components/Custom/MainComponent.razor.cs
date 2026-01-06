namespace Phase03SimpleCrafting.Components.Custom;
public partial class MainComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    private bool CanCraftFlour => state.CanCraft(EnumJobType.Flour);
    private bool CanCraftSugar => state.CanCraft(EnumJobType.Sugar);
    private void CraftFlour()
    {
        state.StartWindmillJob(EnumJobType.Flour);
    }
    private void CraftSugar()
    {
        state.StartWindmillJob(EnumJobType.Sugar);
    }
}