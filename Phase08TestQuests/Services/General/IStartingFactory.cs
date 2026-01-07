namespace Phase08TestQuests.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(PlayerState player);
}