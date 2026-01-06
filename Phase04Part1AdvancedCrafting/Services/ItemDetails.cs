namespace Phase04Part1AdvancedCrafting.Services;
public class ItemDetails
{
    public EnumItemType Name { get; set; }
    public string CraftingTime { get; set; } = ""; //this is for display
    public int CurrentCount { get; set; }
}