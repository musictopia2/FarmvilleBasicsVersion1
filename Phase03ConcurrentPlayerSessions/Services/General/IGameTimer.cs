namespace Phase03ConcurrentPlayerSessions.Services.General;
public interface IGameTimer
{
    void Tick();
    Task SetThemeContextAsync(PlayerState player);
    MainFarmContainer FarmContainer { get; }
    PlayerState? PlayerState { get; }
}