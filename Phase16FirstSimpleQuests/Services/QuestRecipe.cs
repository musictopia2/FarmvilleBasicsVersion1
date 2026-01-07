namespace Phase16FirstSimpleQuests.Services;
public class QuestRecipe
{
    public EnumItemType Item { get; set; }
    public int Required { get; set; } //once you complete, then removes from inventory.
    public bool Completed { get; set; }
}
