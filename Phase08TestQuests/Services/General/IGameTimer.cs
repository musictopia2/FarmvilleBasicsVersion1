namespace Phase08TestQuests.Services.General;
public interface IGameTimer
{
    Task TickAsync();
    Task SetThemeContextAsync(PlayerState player);
    MainFarmContainer FarmContainer { get; }
    PlayerState? PlayerState { get; }
}