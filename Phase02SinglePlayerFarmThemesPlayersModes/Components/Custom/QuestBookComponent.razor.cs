namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Custom;
public partial class QuestBookComponent(Inventory inventory) : InventoryAwareComponentBase
{
    override protected Inventory Inventory => inventory;
}

//public partial class QuestBookComponent(Inventory inventory, QuestManager manager) : InventoryAwareComponentBase
//{
//    override protected Inventory Inventory => inventory;

//    private BasicList<QuestRecipe> _incompleteQuests = [];
//    private void LoadQuests()
//    {
//        _incompleteQuests = manager.ShowCurrentQuests();
//    }
//    protected override void OnInitialized()
//    {
//        LoadQuests();
//        base.OnInitialized();
//    }
//    protected override Task OnInventoryChangedAsync()
//    {
//        LoadQuests();
//        return base.OnInventoryChangedAsync();
//    }
//    private bool CanCompleteQuest(QuestRecipe recipe) => manager.CanCompleteQuest(recipe);
//    private void CompleteQuest(QuestRecipe recipe)
//    {
//        manager.CompleteQuest(recipe);
//        LoadQuests();
//    }
//    private static string Display(QuestRecipe recipe) => $"{recipe.Item} needs {recipe.Required}";
//}