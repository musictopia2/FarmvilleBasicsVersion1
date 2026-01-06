using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phase01.Services;

public class GameTimerService : BackgroundService
{
    private readonly GameState _gameState;

    public GameTimerService(GameState gameState)
    {
        _gameState = gameState;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _gameState.Tick();
            }
            catch
            {
                // ignore
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
