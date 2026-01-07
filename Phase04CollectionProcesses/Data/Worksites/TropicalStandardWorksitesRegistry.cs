namespace Phase04CollectionProcesses.Data.Worksites;
public class TropicalStandardWorksitesRegistry : IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> IWorksiteRegistry.GetWorksitesAsync()
    {
        BasicList<WorksiteRecipe> output = [];
        WorksiteRecipe recipe = new()
        {
            StartText = "Go snorkeling!",
            Location = TropicalWorksiteListClass.CorelReef,
            Duration = TimeSpan.FromMinutes(15),
            MaximumWorkers = 3
        };
        recipe.Inputs.Add(TropicalItemList.PineappleSmootie, 2);
        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = TropicalItemList.Crabs,
            EachWorkerGivesOne = true
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Chance = 0.25,
            Item = TropicalItemList.Seashell
        };
        recipe.BaselineBenefits.Add(benefit);
        //later will figure out something else you get from the corel reef

        output.Add(recipe);
        recipe = new()
        {
            StartText = "Take a hot soak!",
            Location = TropicalWorksiteListClass.HotSprings,
            Duration = TimeSpan.FromHours(2),
            MaximumWorkers = 4
        };
        recipe.Inputs.Add(TropicalItemList.Ceviche, 1);

        benefit = new()
        {
            Guarantee = true,
            Item = TropicalItemList.Clay,
            EachWorkerGivesOne = true
        };
        recipe.BaselineBenefits.Add(benefit);


        benefit = new()
        {
            Item = TropicalItemList.Vanilla,
            Chance = 0.13
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = TropicalItemList.Jasmine,
            Chance = 0.3
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        return Task.FromResult(output);
    }
}