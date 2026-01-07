namespace Phase09MVP1.Services.General;
public interface IGameTimer
{
    Task TickAsync();
    Task SetThemeContextAsync(FarmKey farm);
    MainFarmContainer FarmContainer { get; }
    FarmKey? FarmKey { get; }
}