namespace Phase18SampleUpgrades.Data.Workshops;
public class WorkshopRecipesRegistry : IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> IWorkshopRegistry.GetWorkshopRecipesAsync()
    {
        BasicList<WorkshopRecipe> output = [];
        output.Add(new WorkshopRecipe
        {
            Item = ItemList.Flour,
            BuildingName = WorkshopList.Windill,
            Inputs = { [ItemList.Wheat] = 3 },
            Output = new ItemAmount(ItemList.Flour, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        output.Add(new WorkshopRecipe
        {
            Item = ItemList.Sugar,
            BuildingName = WorkshopList.Windill,
            Inputs = { [ItemList.Corn] = 2 },
            Output = new ItemAmount(ItemList.Sugar, 1),
            Duration = TimeSpan.FromSeconds(20)
        });

        output.Add(new WorkshopRecipe
        {
            Item = ItemList.Biscuits,
            BuildingName = WorkshopList.PastryOven,
            Inputs =
            {
                [ItemList.Flour] = 1,
                [ItemList.Milk] = 1
            },
            Output = new ItemAmount(ItemList.Biscuits, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        output.Add(new WorkshopRecipe
        {
            Item = ItemList.ApplePies,
            BuildingName = WorkshopList.PastryOven,
            Inputs =
            {
                [ItemList.Flour] = 2,
                [ItemList.Apples] = 4,
                [ItemList.Milk] = 1
            },
            Output = new ItemAmount(ItemList.ApplePies, 1),
            Duration = TimeSpan.FromSeconds(20)
        });
        return Task.FromResult(output);
    }
}