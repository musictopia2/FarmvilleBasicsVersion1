namespace Phase08TestQuests.DataAccess.Quests;
public class QuestDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<QuestRecipe> Quests { get; set; }
}