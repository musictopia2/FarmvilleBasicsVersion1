namespace Phase08TestQuests.Components.Custom;

public partial class QuestBookComponent
{

    private BasicList<QuestRecipe> _incompleteQuests = [];


    private void LoadQuests()
    {
        _incompleteQuests = Farm!.QuestManager.ShowCurrentQuests();
    }
    protected override void OnInitialized()
    {
        LoadQuests();
        base.OnInitialized();
    }
    protected override Task OnInventoryChangedAsync()
    {
        LoadQuests();
        return base.OnInventoryChangedAsync();
    }
    private bool CanCompleteQuest(QuestRecipe recipe) => Farm!.QuestManager.CanCompleteQuest(recipe);
    private async Task CompleteQuestAsync(QuestRecipe recipe)
    {
        if (CanCompleteQuest(recipe) == false)
        {
            return;
        }
        await Farm!.QuestManager.CompleteQuestAsync(recipe);
        LoadQuests();
    }
    //for now until i do images for quest ui.
    private static string Display(QuestRecipe recipe) => $"{recipe.Item} needs {recipe.Required}";


    private int InventoryAmount(string itemKey)
    {
        // Whatever your inventory lookup is.
        // Example placeholder:
        return Inventory.Get(itemKey);
    }

    private string GetItemImageSrc(string itemKey)
    {
        // Use the same mapping you already use elsewhere.
        return $"/{itemKey}.png";
    }

}