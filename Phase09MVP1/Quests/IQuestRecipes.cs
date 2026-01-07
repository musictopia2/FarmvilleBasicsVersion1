namespace Phase09MVP1.Quests;
public interface IQuestRecipes
{
    Task<BasicList<QuestRecipe>> GetQuestsAsync();
}