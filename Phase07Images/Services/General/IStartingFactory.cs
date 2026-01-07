namespace Phase07Images.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(PlayerState player);
}