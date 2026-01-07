namespace Phase09MVP1.Services.General;
public interface IInventoryPersistence
{
    Task SaveInventoryAsync(FarmKey farm, Dictionary<string, int> items);
}