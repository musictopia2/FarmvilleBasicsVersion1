namespace Phase09MVP1.DataAccess.Quests;
public class QuestDocument
{
    required public FarmKey Farm { get; set; }
    required public BasicList<QuestRecipe> Quests { get; set; }
}