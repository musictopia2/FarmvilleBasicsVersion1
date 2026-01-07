using rr1 = CommonBasicLibraries.AdvancedGeneralFunctionsAndProcesses.RandomGenerator.RandomHelpers; //not common enough this time.
namespace Phase17BeginningDataAbstractionsPart1.Quests;
public class QuestGroup
{
    public int QuestsToGenerate { get; set; } = 1; //most has 1 but can have more.

    // Item-level constraints
    public BasicList<QuestItemRule> ItemRules { get; set; } = [];
    public BasicList<ItemAmount> GenerateQuests()
    {
        var firsts = ItemRules.GetRandomList(false, QuestsToGenerate);
        BasicList<ItemAmount> output = [];
        foreach (var item in firsts)
        {
            int amount = rr1.GetRandomGenerator().GetRandomNumber(item.MaxQuantity, item.MinQuantity);
            output.Add(new(item.Item, amount));
        }
        return output;
    }
}
