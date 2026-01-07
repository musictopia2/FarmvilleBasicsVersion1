namespace Phase05UseRealDatabase.Components.Custom;
public partial class WorkshopComponent
{
    [Parameter]
    [EditorRequired]
    public WorkshopView Workshop { get; set; }
    private int _selectedIndex = 0;
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
        if (_recipes.Count > 0)
        {
            _selectedIndex = WorkshopStateStore.GetSelectedRecipe(Workshop.Id);
            _selectedIndex = Math.Clamp(_selectedIndex, 0, _recipes.Count - 1);
        }
        else
        {
            _selectedIndex = -1; // No recipes available
        }
        base.OnParametersSet();
    }
    private WorkshopRecipeSummary CurrentRecipe => _recipes[_selectedIndex];
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
    private bool CanGoUp => _selectedIndex > 0;
    private bool CanGoDown => _selectedIndex < _recipes.Count - 1;
    private void GoUp()
    {
        _selectedIndex--;
        WorkshopStateStore.SetSelectedRecipe(Workshop.Id, _selectedIndex);
    }
    private void GoDown()
    {
        _selectedIndex++;
        WorkshopStateStore.SetSelectedRecipe(Workshop.Id, _selectedIndex);
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