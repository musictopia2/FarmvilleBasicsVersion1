namespace Phase05UseRealDatabase.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(PlayerState player);
}