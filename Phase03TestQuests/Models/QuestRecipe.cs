namespace Phase03TestQuests.Models;
public class QuestRecipe
{
    public string Item { get; set; } = "";
    public int Required { get; set; } //once you complete, then removes from inventory.
    public bool Completed { get; set; }
    //these 2 are needed to hep in generating the quests.
    public EnumQuestSourceKind SourceKind { get; set; }
    public string ProducerId { get; set; } = "";
}