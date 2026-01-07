namespace Phase15CombineBasicMechanics.Services;
public class Inventory
{
    private readonly Dictionary<int, int> _items = [];
    //could be okay because i already have a custom way of getting a list of all possible items anyways.
    public int Get(EnumItemType item)
    {
        int value = item.Value;
        return _items.GetValueOrDefault(value);
    }

    public bool Has(EnumItemType item, int amount)
        => Get(item) >= amount;

    public bool Has(Dictionary<EnumItemType, int> requirements)
        => requirements.All(r => Has(r.Key, r.Value));

    public void Add(EnumItemType item, int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        int value = item.Value;
        _items[value] = Get(item) + amount;
    }

    public void Consume(EnumItemType item, int amount)
    {
        if (Has(item, amount) == false)
        {
            throw new InvalidOperationException("Not enough items");
        }
        int key = item.Value;
        _items[key] -= amount;
    }

    public void Consume(Dictionary<EnumItemType, int> requirements)
    {
        if (Has(requirements) == false)
        {
            throw new InvalidOperationException("Not enough items");
        }
        foreach (var req in requirements)
        {
            int key = req.Key.Value;
            _items[key] -= req.Value;
        }
    }
}
