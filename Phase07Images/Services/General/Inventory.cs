namespace Phase07Images.Services.General;
public class Inventory(PlayerState player, IInventoryPersistence persist)
{
    private readonly Dictionary<string, int> _items = [];
    public event Action? InventoryChanged;
    public void LoadStartingInventory(Dictionary<string, int> items)
    {
        _items.Clear();
        foreach (var item in items)
        {
            _items.Add(item.Key, item.Value);
        }
        InventoryChanged?.Invoke(); //not sure but do just in case.
    }
    public int Get(string item)
    {
        return _items.GetValueOrDefault(item);
    }
    public bool Has(string item, int amount)
        => Get(item) >= amount;
    public bool Has(Dictionary<string, int> requirements)
        => requirements.All(r => Has(r.Key, r.Value));
    public void Add(string item, int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        _items[item] = Get(item) + amount;
        Update();
    }
    private async void Update()
    {
        await persist.SaveInventoryAsync(player, _items);
        InventoryChanged?.Invoke();
    }
    public void Consume(string item, int amount)
    {
        if (Has(item, amount) == false)
        {
            throw new InvalidOperationException("Not enough items");
        }
        _items[item] -= amount;
        Update();
    }
    public void Consume(Dictionary<string, int> requirements)
    {
        if (Has(requirements) == false)
        {
            throw new InvalidOperationException("Not enough items");
        }
        foreach (var req in requirements)
        {
            _items[req.Key] -= req.Value;
        }
        Update();
    }
    public BasicList<ItemAmount> GetAllInventoryItems()
    {
        return _items
            .Where(kvp => kvp.Value > 0)
            .Select(kvp => new ItemAmount(kvp.Key, kvp.Value))
            .ToBasicList();
    }
}