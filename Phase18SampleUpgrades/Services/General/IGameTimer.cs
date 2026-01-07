namespace Phase18SampleUpgrades.Services.General;
public interface IGameTimer
{
    void Tick();
    Task StartAsync();
}