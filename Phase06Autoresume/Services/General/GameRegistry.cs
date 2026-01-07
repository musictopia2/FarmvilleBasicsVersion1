namespace Phase06Autoresume.Services.General;
public class GameRegistry
{
    private readonly BasicList<IGameTimer> _farms = [];
    public static TimeSpan SaveThrottle { get; set; } = TimeSpan.FromSeconds(2); //for testing.

    public async Task InitializeFarmAsync(IGameTimer timer, PlayerState player)
    {
        await timer.SetThemeContextAsync(player);
        _farms.Add(timer);
    }
    public MainFarmContainer GetFarm(PlayerState state)
    {
        foreach (var farm in _farms)
        {
            CustomBasicException.ThrowIfNull(farm.PlayerState);
            CustomBasicException.ThrowIfNull(farm.FarmContainer);
            if (farm.PlayerState.Equals(state))
            {
                return farm.FarmContainer;
            }
        }
        throw new CustomBasicException($"No farm found for {state}");
    }
    public async Task TickAsync()
    {
        await _farms.ForEachAsync(async farm =>
        {
            await farm.TickAsync();
        });
    }
}
