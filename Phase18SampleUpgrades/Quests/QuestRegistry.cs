namespace Phase18SampleUpgrades.Quests;
public class QuestRegistry
{
    private readonly BasicList<QuestGroup> _groups = [];
    public QuestRegistry()
    {
        GenerateGroups();
    }
    private void GenerateGroups()
    {
        QuestGroup group = new();
        group.QuestsToGenerate = 2;
        QuestItemRule rule = new()
        {
            Item = ItemList.Wheat,
            MinQuantity = 5,
            MaxQuantity = 20
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Corn,
            MinQuantity = 4,
            MaxQuantity = 12
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Honey,
            MinQuantity = 3,
            MaxQuantity = 10
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Shrimp,
            MinQuantity = 8,
            MaxQuantity = 16
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        // QuestsToGenerate = 1 by default
        group = new();
        rule = new()
        {
            Item = ItemList.Milk,
            MinQuantity = 5,
            MaxQuantity = 10
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Eggs,
            MinQuantity = 8,
            MaxQuantity = 15
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Flour,
            MinQuantity = 4,
            MaxQuantity = 12
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Sugar,
            MinQuantity = 8,
            MaxQuantity = 14
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Biscuits,
            MinQuantity = 1,
            MaxQuantity = 4
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.ApplePies,
            MinQuantity = 2,
            MaxQuantity = 6
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Apples,
            MinQuantity = 12,
            MaxQuantity = 30
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Peaches,
            MinQuantity = 6,
            MaxQuantity = 10
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Blackberries,
            MinQuantity = 3,
            MaxQuantity = 7
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Trout,
            MinQuantity = 2,
            MaxQuantity = 5
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Strawberries,
            MinQuantity = 1,
            MaxQuantity = 3
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Carrots,
            MinQuantity = 1,
            MaxQuantity = 2
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.GranillaBars,
            MinQuantity = 1,
            MaxQuantity = 4
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = ItemList.Mint,
            MinQuantity = 1,
            MaxQuantity = 1
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Bass,
            MinQuantity = 1,
            MaxQuantity = 1
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = ItemList.Chives,
            MinQuantity = 2,
            MaxQuantity = 5
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        // Total quests across all groups must equal 10
    }
    public BasicList<QuestRecipe> GenerateQuests()
    {
        BasicList<QuestRecipe> output = [];
        foreach (var item in _groups)
        {
            BasicList<ItemAmount> list = item.GenerateQuests();
            foreach (var g in list)
            {
                QuestRecipe recipe = new()
                {
                    Item = g.Item,
                    Required = g.Amount,
                    Completed = false
                };
                output.Add(recipe);
            }
        }
        output.ShuffleList(); //i want this shuffled
        if (output.Count != 10)
        {
            throw new CustomBasicException("Must have 10 quests.  Must be a bug");
        }
        // Total quests across all groups must equal 10
        return output;
    }
}