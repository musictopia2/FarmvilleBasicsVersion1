namespace Phase16FirstSimpleQuests.Services;
public class QuestRegistry
{
    private BasicList<QuestGroup> _groups = [];
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
            Item = EnumItemType.Wheat,
            MinQuantity = 5,
            MaxQuantity = 20
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Corn,
            MinQuantity = 4,
            MaxQuantity = 12
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Honey,
            MinQuantity = 3,
            MaxQuantity = 10
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Shrimp,
            MinQuantity = 8,
            MaxQuantity = 16
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        // QuestsToGenerate = 1 by default
        group = new();
        rule = new()
        {
            Item = EnumItemType.Milk,
            MinQuantity = 5,
            MaxQuantity = 10
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Eggs,
            MinQuantity = 8,
            MaxQuantity = 15
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Flour,
            MinQuantity = 4,
            MaxQuantity = 12
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Sugar,
            MinQuantity = 8,
            MaxQuantity = 14
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Biscuits,
            MinQuantity = 3,
            MaxQuantity = 8
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.ApplePies,
            MinQuantity = 5,
            MaxQuantity = 12
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Apples,
            MinQuantity = 12,
            MaxQuantity = 30
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Peaches,
            MinQuantity = 6,
            MaxQuantity = 10
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Blackberries,
            MinQuantity = 3,
            MaxQuantity = 7
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Trout,
            MinQuantity = 2,
            MaxQuantity = 5
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Strawberries,
            MinQuantity = 1,
            MaxQuantity = 3
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Carrots,
            MinQuantity = 1,
            MaxQuantity = 2
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.GranillaBars,
            MinQuantity = 1,
            MaxQuantity = 4
        };
        group.ItemRules.Add(rule);
        _groups.Add(group);
        group = new();
        rule = new()
        {
            Item = EnumItemType.Mint,
            MinQuantity = 1,
            MaxQuantity = 1
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Bass,
            MinQuantity = 1,
            MaxQuantity = 1
        };
        group.ItemRules.Add(rule);
        rule = new()
        {
            Item = EnumItemType.Chives,
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