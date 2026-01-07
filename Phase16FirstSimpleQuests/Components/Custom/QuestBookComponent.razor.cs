namespace Phase16FirstSimpleQuests.Components.Custom;
public partial class QuestBookComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    private BasicList<QuestRecipe> _incompleteQuests = [];
    private void LoadQuests()
    {
        _incompleteQuests = state.ShowCurrentQuests();
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }
    private bool CanCompleteQuest(QuestRecipe recipe) => state.CanCompleteQuest(recipe);
    private void CompleteQuest(QuestRecipe recipe)
    {
        state.CompleteQuest(recipe);
        LoadQuests();
    }
    protected override void OnInitialized()
    {
        LoadQuests();
    }
    private static string Display(QuestRecipe recipe) => $"{recipe.Item} needs {recipe.Required}";
}