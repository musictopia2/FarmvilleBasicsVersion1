namespace Phase06Autoresume.DataAccess.General;
public class StartingFactory : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices(PlayerState player)
    {
        return new InventoryDatabase();
    }
}