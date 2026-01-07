namespace Phase03ConcurrentPlayerSessions.Data.Worksites;
public class TropicalTestWorksitesRegistry : IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> IWorksiteRegistry.GetWorksitesAsync()
    {
        BasicList<WorksiteRecipe> output = [];
        WorksiteRecipe recipe = new()
        {
            StartText = "Go snorkeling!",
            Location = TropicalWorksiteListClass.CorelReef,
            Duration = TimeSpan.FromSeconds(15),
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
        //for testing, don't worry about the one item that is very rare for tropic escape.

        //benefit = new()
        //{
        //    Chance = 0.03,
        //    Item = ItemList.BarnNail
        //};
        //recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        recipe = new()
        {
            StartText = "Take a hot soak!",
            Location = TropicalWorksiteListClass.HotSprings,
            Duration = TimeSpan.FromSeconds(45), //otherwise, much harder to test.
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