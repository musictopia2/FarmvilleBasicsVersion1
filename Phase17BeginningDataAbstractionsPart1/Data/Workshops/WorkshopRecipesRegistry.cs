namespace Phase17BeginningDataAbstractionsPart1.Data.Workshops;
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
            Item = ItemList.Biscuit,
            BuildingName = WorkshopList.PastryOven,
            Inputs =
            {
                [ItemList.Flour] = 1,
                [ItemList.Milk] = 1
            },
            Output = new ItemAmount(ItemList.Biscuit, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        output.Add(new WorkshopRecipe
        {
            Item = ItemList.ApplePie,
            BuildingName = WorkshopList.PastryOven,
            Inputs =
            {
                [ItemList.Flour] = 2,
                [ItemList.Apple] = 4,
                [ItemList.Milk] = 1
            },
            Output = new ItemAmount(ItemList.ApplePie, 1),
            Duration = TimeSpan.FromSeconds(20)
        });
        return Task.FromResult(output);
    }
}