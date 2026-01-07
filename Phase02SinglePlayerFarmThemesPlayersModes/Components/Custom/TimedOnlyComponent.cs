namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Custom;
public abstract class TimedOnlyComponent : ComponentBase, IDisposable
{
    private PeriodicTimer? _timer;
    private CancellationTokenSource? _cts;

    protected override void OnInitialized()
    {
        _cts = new CancellationTokenSource();
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

        _ = RunTimerAsync();

        base.OnInitialized();
    }

    private async Task RunTimerAsync()
    {
        try
        {
            while (await _timer!.WaitForNextTickAsync(_cts!.Token))
            {
                await OnTickAsync();
            }
        }
        catch (OperationCanceledException)
        {
            // Expected on dispose
        }
    }

    protected virtual Task OnTickAsync()
        => InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        _cts?.Cancel();
        _timer?.Dispose();
        _cts?.Dispose();
        GC.SuppressFinalize(this);
    }
}
