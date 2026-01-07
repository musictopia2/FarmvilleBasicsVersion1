namespace Phase05UseRealDatabase.DataAccess.General;
public class StartingFactory : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices(PlayerState player)
    {
        return new InventoryDatabase();
    }
}