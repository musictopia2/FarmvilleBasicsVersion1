namespace Phase09SingleTrees.Components.Custom;
public partial class MainComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    private bool CanCollectApples => state.ApplesReady > 0;
    private void CollectApple()
    {
        state.CollectApple();
    }
    private string ReadyText => $"Ready In {state.TimeLeftForApples}";
}