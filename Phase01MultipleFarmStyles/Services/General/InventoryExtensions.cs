namespace Phase01MultipleFarmStyles.Services.General;

public static class InventoryExtensions
{
    extension(Inventory inventory)
    {
        public int GetInventoryCount(string item) => inventory.Get(item);

    }
}
