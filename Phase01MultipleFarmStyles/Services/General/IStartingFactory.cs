namespace Phase01MultipleFarmStyles.Services.General;
public interface IStartingFactory
{
    IStartingInventoryProvider GetInventoryServices(string style);
}