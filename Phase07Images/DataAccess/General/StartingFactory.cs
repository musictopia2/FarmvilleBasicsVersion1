namespace Phase07Images.DataAccess.General;
public class StartingFactory : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices(PlayerState player)
    {
        return new InventoryDatabase();
    }
}