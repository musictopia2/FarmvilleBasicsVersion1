namespace Phase09MVP1.Quests;
public interface IQuestPersistence
{
    Task SaveQuestsAsync(BasicList<QuestRecipe> quests);
}