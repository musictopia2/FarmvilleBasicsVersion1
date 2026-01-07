namespace Phase01MultipleFarmStyles.Services.General;
public interface IGameTimer
{
    void Tick();
    Task SetStyleContextAsync(string style);
    //Task StartAsync();
}