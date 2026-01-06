namespace Phase04Part1AdvancedCrafting.Components.Custom;
public partial class PastryOvenComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    EnumItemType _chosen = EnumItemType.Biscuits;
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }


    private void ViewBiscuitsDetails()
    {
        _chosen = EnumItemType.Biscuits;
    }
    private void ViewApplePiesDetails()
    {
        _chosen = EnumItemType.ApplePie;
    }

    private bool CanCraft => state.CanCraftFromPastryOven(_chosen);
    //private bool CanCraftSugar => state.CanCraftFromWindmill(EnumItemType.Sugar);
    private void Craft()
    {
        state.StartPastryOvenJob(_chosen);
    }

    private int CurrentAmount => state.GetInventoryCount(_chosen);

    private string GetTime
    {
        get
        {
            RecipeModel recipe = GetRecipe(_chosen);
            return recipe.Duration.GetTimeString;
        }
    }

    private bool CanGoUp => _chosen == EnumItemType.ApplePie;

    private bool CanGoDown => _chosen == EnumItemType.Biscuits;

    private void GoUp()
    {
        ViewBiscuitsDetails();
    }
    private void GoDown()
    {
        ViewApplePiesDetails();
    }
    private RecipeModel GetRecipe(EnumItemType item)
    {
        return state.GetRecipe(item);
    }
    private Dictionary<EnumItemType, int> FullRequirements
    {
        get
        {
            RecipeModel recipe = GetRecipe(_chosen);
            return recipe.Inputs;
        }
    }

    private string GetRequirementClass(EnumItemType item, int required)
    {
        if (state.HasPartialRequirement(item, required))
        {
            return css1.TextSuccess;
        }
        return css1.TextDanger;
    }
    private string GetRequirementDetails(EnumItemType item, int required)
    {
        int count = state.GetInventoryCount(item);
        return $"{count}/{required}";
    }
    private static string CraftingDetails(CraftingJob craft)
    {
        return $"Crafting {craft.Recipe.Item} {craft.ProgressSeconds.GetTimeString}";
    }
}