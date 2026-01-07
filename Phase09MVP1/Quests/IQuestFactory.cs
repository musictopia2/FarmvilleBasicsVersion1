namespace Phase09MVP1.Quests;
public interface IQuestFactory
{
    QuestServicesContext GetQuestServices(FarmKey farm);
}