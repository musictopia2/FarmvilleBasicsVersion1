namespace Phase14MultipleWorksites.Services;
public class WorksiteRecipe
{
    public Dictionary<EnumItemType, int> Inputs { get; init; } = [];
    public EnumWorksiteLocation Location { get; set; } //try to put location here.
    public TimeSpan Duration { get; init; }
    public BasicList<WorksiteBaselineBenefit> BaselineBenefits { get; init; } = [];
    public int MaximumWorkers { get; set; }
    required
    public string StartText { get; init; }
}