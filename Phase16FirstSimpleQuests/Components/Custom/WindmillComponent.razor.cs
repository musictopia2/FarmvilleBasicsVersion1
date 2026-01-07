namespace Phase16FirstSimpleQuests.Components.Custom;
public partial class WindmillComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;

    EnumItemType _chosen = EnumItemType.Flour;

    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
    }


    private void ViewFlourDetails()
    {
        _chosen = EnumItemType.Flour;
    }
    private void ViewSugarDetails()
    {
        _chosen = EnumItemType.Sugar;
    }

    private bool CanCraft => state.CanCraftFromWindmill(_chosen);
    //private bool CanCraftSugar => state.CanCraftFromWindmill(EnumItemType.Sugar);
    private void Craft()
    {
        state.StartWindmillJob(_chosen);
    }
    
    private int CurrentAmount => state.GetInventoryCount(_chosen);

    private string GetTime
    {
        get
        {
            BuildingRecipeModel recipe = GetRecipe(_chosen);
            return recipe.Duration.GetTimeString;
        }
    }

    private bool CanGoUp => _chosen == EnumItemType.Sugar;

    private bool CanGoDown => _chosen == EnumItemType.Flour;

    private void GoUp()
    {
        ViewFlourDetails();
    }
    private void GoDown()
    {
        ViewSugarDetails();
    }
    private BuildingRecipeModel GetRecipe(EnumItemType item)
    {
        return state.GetRecipe(item);
    }
    private Dictionary<EnumItemType, int> FullRequirements
    {
        get
        {
            BuildingRecipeModel recipe = GetRecipe(_chosen);
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
        return $"Crafting {craft.Recipe.Item} {craft.ReadyTime?.GetTimeString}";
    }
}