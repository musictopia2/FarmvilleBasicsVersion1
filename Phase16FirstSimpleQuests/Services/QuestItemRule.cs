namespace Phase16FirstSimpleQuests.Services;
public class QuestItemRule
{
    public EnumItemType Item { get; set; }
    // Quantity bounds for this specific item
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
}