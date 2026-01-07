namespace Phase08TestQuests.Quests;
public interface IQuestFactory
{
    QuestServicesContext GetQuestServices(PlayerState player);
}