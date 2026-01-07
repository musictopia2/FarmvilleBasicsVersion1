namespace Phase06Autoresume.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(PlayerState player);
}