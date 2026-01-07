namespace Phase07Images.Services.General;
public interface IInventoryPersistence
{
    Task SaveInventoryAsync(PlayerState player, Dictionary<string, int> items);
}