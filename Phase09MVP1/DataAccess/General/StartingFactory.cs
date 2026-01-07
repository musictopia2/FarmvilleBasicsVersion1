namespace Phase09MVP1.DataAccess.General;
public class StartingFactory : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices(FarmKey farm)
    {
        return new InventoryDatabase();
    }
}