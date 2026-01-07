namespace Phase03ConcurrentPlayerSessions.Data.Workshops;
public class CountryStandardWorkshopRecipesRegistry : IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> IWorkshopRegistry.GetWorkshopRecipesAsync()
    {
        BasicList<WorkshopRecipe> output = [];
        output.Add(new WorkshopRecipe
        {
            Item = CountryItemList.Flour,
            BuildingName = CountryWorkshopList.Windill,
            Inputs = { [CountryItemList.Wheat] = 3 },
            Output = new ItemAmount(CountryItemList.Flour, 1),
            Duration = TimeSpan.FromSeconds(30)
        });

        output.Add(new WorkshopRecipe
        {
            Item = CountryItemList.Sugar,
            BuildingName = CountryWorkshopList.Windill,
            Inputs = { [CountryItemList.Corn] = 2 },
            Output = new ItemAmount(CountryItemList.Sugar, 1),
            Duration = TimeSpan.FromMinutes(2)
        });

        output.Add(new WorkshopRecipe
        {
            Item = CountryItemList.Biscuits,
            BuildingName = CountryWorkshopList.PastryOven,
            Inputs =
            {
                [CountryItemList.Flour] = 1,
                [CountryItemList.Milk] = 1
            },
            Output = new ItemAmount(CountryItemList.Biscuits, 1),
            Duration = TimeSpan.FromSeconds(30)
        });

        output.Add(new WorkshopRecipe
        {
            Item = CountryItemList.ApplePies,
            BuildingName = CountryWorkshopList.PastryOven,
            Inputs =
            {
                [CountryItemList.Flour] = 2,
                [CountryItemList.Apples] = 4,
                [CountryItemList.Milk] = 1
            },
            Output = new ItemAmount(CountryItemList.ApplePies, 1),
            Duration = TimeSpan.FromMinutes(1)
        });
        return Task.FromResult(output);
    }
}