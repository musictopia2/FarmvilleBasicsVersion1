namespace Phase17BeginningDataAbstractionsPart1.Data.Worksites;
public class WorksitesRegistry : IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> IWorksiteRegistry.GetWorksitesAsync()
    {
        BasicList<WorksiteRecipe> output = [];
        WorksiteRecipe recipe = new()
        {
            StartText = "Go Foraging!",
            Location = WorksiteListClass.GrandmasGlade,
            Duration = TimeSpan.FromSeconds(15),
            MaximumWorkers = 2
        };
        recipe.Inputs.Add(ItemList.Biscuit, 1);
        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = ItemList.Blackberry
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.4,
            Item = ItemList.Chive
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.03,
            Item = ItemList.BarnNail
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        recipe = new()
        {
            StartText = "Go Fishing!",
            Location = WorksiteListClass.Pond,
            Duration = TimeSpan.FromSeconds(45), //otherwise, much harder to test.
            MaximumWorkers = 4
        };
        recipe.Inputs.Add(ItemList.Biscuit, 1);
        recipe.Inputs.Add(ItemList.FarmersSoup, 1);

        benefit = new()
        {
            Guarantee = true,
            Item = ItemList.Trout
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = ItemList.Padlock,
            Chance = 0.03
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = ItemList.BarnNail,
            Chance = 0.06
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = ItemList.Bass,
            Chance = 0.11
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = ItemList.Mint,
            Chance = 0.13
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        return Task.FromResult(output);
    }
}