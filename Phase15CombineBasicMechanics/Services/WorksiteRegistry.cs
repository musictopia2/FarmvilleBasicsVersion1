namespace Phase15CombineBasicMechanics.Services;
public class WorksiteRegistry
{
    //this focus on registry stuff.
    private readonly BasicList<WorksiteRecipe> _recipes = [];
    public IReadOnlyList<WorksiteRecipe> All => _recipes;
    public WorksiteRegistry()
    {
        LoadGrandmasGlade();
        LoadPond();
    }
    private void LoadGrandmasGlade()
    {
        WorksiteRecipe recipe = new()
        {
            StartText = "Go Foraging!",
            Location = EnumWorksiteLocation.GrandmasGlade,
            Duration = TimeSpan.FromSeconds(15),
            MaximumWorkers = 2
        };
        recipe.Inputs.Add(EnumItemType.Biscuits, 1);
        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = EnumItemType.Blackberries
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.4,
            Item = EnumItemType.Chives
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.03,
            Item = EnumItemType.BarnNail
        };
        recipe.BaselineBenefits.Add(benefit);
        _recipes.Add(recipe);
    }
    private void LoadPond()
    {
        WorksiteRecipe recipe = new()
        {
            StartText = "Go Fishing!",
            Location = EnumWorksiteLocation.Pond,
            Duration = TimeSpan.FromSeconds(45), //otherwise, much harder to test.
            MaximumWorkers = 4
        };
        recipe.Inputs.Add(EnumItemType.Biscuits, 1);
        recipe.Inputs.Add(EnumItemType.FarmersSoup, 1);

        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = EnumItemType.Trout
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = EnumItemType.Padlocks,
            Chance = 0.03
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = EnumItemType.BarnNail,
            Chance = 0.06
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = EnumItemType.Bass,
            Chance = 0.11
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = EnumItemType.Mint,
            Chance = 0.13
        };
        recipe.BaselineBenefits.Add(benefit);
        _recipes.Add(recipe);
    }
    public WorksiteRecipe ForWorksite(EnumWorksiteLocation location)
        => _recipes.Single(r => r.Location == location);
    //probably can't get by name this time since you are not returning an inventory item.

}
