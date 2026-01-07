namespace Phase09MVP1.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(FarmKey farm);
}