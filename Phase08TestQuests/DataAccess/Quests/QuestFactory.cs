namespace Phase08TestQuests.DataAccess.Quests;
public class QuestFactory : IQuestFactory
{
    QuestServicesContext IQuestFactory.GetQuestServices(PlayerState player)
    {
        QuestInstanceDatabase db = new(player);
        return new()
        {
            QuestPersistence = db,
            QuestRecipes = db,
        };
    }
}