namespace Phase09SingleTrees.Services;
public class GameState : IGameTimer
{
    public const int TotalFromTrees = 4;
    public int AppleInventory { get; private set; }
    readonly AppleClass _apples = new();
    public int ApplesReady => _apples.ApplesReady;
    public string TimeLeftForApples => _apples.ReadyTime!.Value!.GetTimeString;
    public EnumTreeState GetAppleState => _apples.State;
    public void CollectApple()
    {
        _apples.CollectApple();
        AppleInventory++;
    }
    void IGameTimer.Tick()
    {
        _apples.UpdateTick();
    }
}