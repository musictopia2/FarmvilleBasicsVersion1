namespace Phase16FirstSimpleQuests.Components.Custom;
public partial class PeachTreeComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }

    private bool CanCollectPeaches => state.PeachesReady > 0;
    private void CollectPeach()
    {
        state.CollectPeach();
    }
    private string ReadyText => $"Ready In {state.TimeLeftForPeaches}";


}