namespace Phase09MVP1.Services.General;
public static class InventoryExtensions
{
    extension(Inventory inventory)
    {
        public int GetInventoryCount(string item) => inventory.Get(item);
    }
}