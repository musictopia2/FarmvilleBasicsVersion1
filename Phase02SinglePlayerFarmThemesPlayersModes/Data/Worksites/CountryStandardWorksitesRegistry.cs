namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Worksites;
public class CountryStandardWorksitesRegistry : IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> IWorksiteRegistry.GetWorksitesAsync()
    {
        BasicList<WorksiteRecipe> output = [];
        WorksiteRecipe recipe = new()
        {
            StartText = "Go Foraging!",
            Location = CountryWorksiteListClass.GrandmasGlade,
            Duration = TimeSpan.FromMinutes(15),
            MaximumWorkers = 2
        };
        recipe.Inputs.Add(CountryItemList.Biscuits, 1);
        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = CountryItemList.Blackberries
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.4,
            Item = CountryItemList.Chives
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.03,
            Item = CountryItemList.BarnNail
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        recipe = new()
        {
            StartText = "Go Fishing!",
            Location = CountryWorksiteListClass.Pond,
            Duration = TimeSpan.FromHours(8),
            MaximumWorkers = 4
        };
        recipe.Inputs.Add(CountryItemList.Biscuits, 1);
        recipe.Inputs.Add(CountryItemList.FarmersSoup, 1);

        benefit = new()
        {
            Guarantee = true,
            Item = CountryItemList.Trout
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Padlocks,
            Chance = 0.03
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.BarnNail,
            Chance = 0.06
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Bass,
            Chance = 0.11
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Mint,
            Chance = 0.13
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        return Task.FromResult(output);
    }
}