namespace Phase17BeginningDataAbstractionsPart1.Services.General;
public interface IGameTimer
{
    void Tick();
    Task StartAsync();
}