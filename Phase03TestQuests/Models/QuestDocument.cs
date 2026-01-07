namespace Phase03TestQuests.Models;
public class QuestDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<QuestRecipe> Quests { get; set; }
}