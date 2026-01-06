namespace Phase04Part1AdvancedCrafting.Services;
public class RecipeModel
{
    //apples will never have a recipe but would for apple pies and flour.
    //flour only has one input but apple pies has 2 inputs.
    //public string Name { get; init; } = "";
    public EnumItemType Item { get; set; } //for now, has to be this so i have intellisense.  later will rethink.
    public EnumBuildingCategory Building { get; init; }
    public Dictionary<EnumItemType, int> Inputs { get; init; } = [];
    public ItemAmount Output { get; init; }
    public TimeSpan Duration { get; init; }
}