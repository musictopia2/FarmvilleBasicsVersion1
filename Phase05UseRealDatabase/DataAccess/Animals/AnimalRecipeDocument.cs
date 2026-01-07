namespace Phase05UseRealDatabase.DataAccess.Animals;
public class AnimalRecipeDocument
{
    public string Animal { get; init; } = "";
    public BasicList<AnimalProductionOption> Options { get; init; } = [];
    required public string Theme { get; init; }
    required public string Mode { get; init; }
}