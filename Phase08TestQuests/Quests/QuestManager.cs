namespace Phase08TestQuests.Quests;
public class QuestManager(Inventory inventory)
{
    private IQuestPersistence _questPersistence = null!;
    private BasicList<QuestRecipe> _quests = [];
    public async Task SetStyleContextAsync(QuestServicesContext context)
    {
        if (_questPersistence != null)
        {
            throw new InvalidOperationException("Persistance Already set");
        }
        _questPersistence = context.QuestPersistence;
        _quests = await context.QuestRecipes.GetQuestsAsync();
    }
    public BasicList<QuestRecipe> ShowCurrentQuests()
    {
        var list = _quests.Where(x => x.Completed == false).Take(3).ToBasicList();
        //once all quests are completed, then game is over.
        return list;
    }
    public bool CanCompleteQuest(QuestRecipe recipe) => inventory.Has(recipe.Item, recipe.Required);
    public async Task CompleteQuestAsync(QuestRecipe recipe)
    {
        if (CanCompleteQuest(recipe) == false)
        {
            throw new CustomBasicException("Unable to complete quest.   Should had called CanCompleteQuest first");
        }
        inventory.Consume(recipe.Item, recipe.Required);
        recipe.Completed = true;
        await _questPersistence.SaveQuestsAsync(_quests);
    }
}