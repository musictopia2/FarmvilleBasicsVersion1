namespace Phase17BeginningDataAbstractionsPart1.Quests;
public class QuestManager(Inventory inventory)
{
    QuestRegistry? _questRegistry;
    private BasicList<QuestRecipe> _completeQuests = [];
    public void PopulateQuests()
    {
        _questRegistry = new();
        _completeQuests = _questRegistry.GenerateQuests();
    }
    public bool CanCompleteQuest(QuestRecipe recipe) => inventory.Has(recipe.Item, recipe.Required);
    public void CompleteQuest(QuestRecipe recipe)
    {
        if (CanCompleteQuest(recipe) == false)
        {
            throw new CustomBasicException("Unable to complete quest.   Should had called CanCompleteQuest first");
        }
        inventory.Consume(recipe.Item, recipe.Required);
        recipe.Completed = true;
    }
    public BasicList<QuestRecipe> ShowCurrentQuests()
    {
        var list = _completeQuests.Where(x => x.Completed == false).Take(3).ToBasicList();
        //once all quests are completed, then game is over.
        return list;
    }
}