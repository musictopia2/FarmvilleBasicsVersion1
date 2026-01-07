namespace Phase06Autoresume.Components.Custom;
public partial class WorkshopComponent
{
    [Parameter]
    [EditorRequired]
    public WorkshopView Workshop { get; set; }
    private BasicList<WorkshopRecipeSummary> _recipes = [];
    private bool _automatePickup;

    protected override async Task OnInitializedAsync()
    {
        _automatePickup = await WorkshopManager.CanAutomateCollectionAsync();
        await base.OnInitializedAsync();
    }
    private bool CanPickupManually => WorkshopManager.CanPickupManually(Workshop);
    private void PickupManually()
    {
        WorkshopManager.PickupManually(Workshop);
    }
    protected override void OnParametersSet()
    {
        _recipes = WorkshopManager.GetRecipesForWorkshop(Workshop);
        // Ensure selected recipe index is within bounds
        if (_recipes.Count > 0)
        {
            Workshop.SelectedRecipeIndex = Math.Clamp(
                Workshop.SelectedRecipeIndex, 0, _recipes.Count - 1
            );
        }
        base.OnParametersSet();
    }
    private WorkshopRecipeSummary CurrentRecipe => _recipes[Workshop.SelectedRecipeIndex];
    private string ChosenItem => CurrentRecipe.Item;
    private bool CanCraft => WorkshopManager.CanCraft(Workshop, ChosenItem);
    private async Task CraftAsync()
    {
        await WorkshopManager.StartCraftingJobAsync(Workshop, ChosenItem);
    }
    private int CurrentAmount => Inventory.GetInventoryCount(ChosenItem);
    private string DurationText
    {
        get
        {
            return CurrentRecipe.Duration.GetTimeString;
        }
    }
    private bool CanGoUp => Workshop.SelectedRecipeIndex > 0;
    private bool CanGoDown => Workshop.SelectedRecipeIndex < _recipes.Count - 1;

    private void GoUp()
    {
        Workshop.SelectedRecipeIndex--;
        WorkshopManager.UpdateSelectedRecipe(Workshop, Workshop.SelectedRecipeIndex);
    }

    private void GoDown()
    {
        Workshop.SelectedRecipeIndex++;
        WorkshopManager.UpdateSelectedRecipe(Workshop, Workshop.SelectedRecipeIndex);
    }
    private Dictionary<string, int> FullRequirements
    {
        get
        {
            return CurrentRecipe.Inputs;
        }
    }

    private string GetRequirementClass(string item, int required)
    {
        if (Inventory.Has(item, required))
        {
            return css1.TextSuccess;
        }
        return css1.TextDanger;
    }
    private string GetRequirementDetails(string item, int required)
    {
        int count = Inventory.GetInventoryCount(item);
        return $"{count}/{required}";
    }
    private static string CraftingDetails(CraftingSummary craft)
    {
        return $"Crafting {craft.Name} {craft.ReadyTime}";
    }
}