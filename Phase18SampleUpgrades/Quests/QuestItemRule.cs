namespace Phase18SampleUpgrades.Quests;
public class QuestItemRule
{
    public string Item { get; set; } = "";
    // Quantity bounds for this specific item
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
}