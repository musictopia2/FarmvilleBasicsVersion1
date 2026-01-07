namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.General;
public interface IGameTimer
{
    void Tick();
    Task SetStyleContextAsync();
    //Task StartAsync();
}