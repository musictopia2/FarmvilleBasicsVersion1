namespace Phase18SampleUpgrades.Services.General;
public class GameTimerService(IGameTimer state) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await state.StartAsync();
        await base.StartAsync(cancellationToken);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                state.Tick();
            }
            catch
            {
                // ignore
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}