namespace Phase01MultipleFarmStyles.Data.Workshops;
public class TropicalWorkshopRecipesRegistry : IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> IWorkshopRegistry.GetWorkshopRecipesAsync()
    {
        BasicList<WorkshopRecipe> output = [];
        output.Add(new WorkshopRecipe
        {
            Item = TropicalItemList.PineappleSmootie,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs = { [TropicalItemList.Pineapples] = 3 },
            Output = new ItemAmount(TropicalItemList.PineappleSmootie, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        output.Add(new WorkshopRecipe
        {
            Item = TropicalItemList.PinaColada,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs =
            { 
                [TropicalItemList.Coconuts] = 3 ,
                [TropicalItemList.Pineapples] = 2
            },
            Output = new ItemAmount(TropicalItemList.PinaColada, 1),
            Duration = TimeSpan.FromSeconds(20)
        });

        output.Add(new WorkshopRecipe
        {
            Item = TropicalItemList.SteamedRice,
            BuildingName = TropicalWorkshopList.SushiStand,
            Inputs =
            {
                [TropicalItemList.Rice] = 2,
            },
            Output = new ItemAmount(TropicalItemList.SteamedRice, 1),
            Duration = TimeSpan.FromSeconds(5)
        });

        output.Add(new WorkshopRecipe
        {
            Item = TropicalItemList.FishRoll,
            BuildingName = TropicalWorkshopList.SushiStand,
            Inputs =
            {
                [TropicalItemList.Fish] = 2,
                [TropicalItemList.SteamedRice] = 1
            },
            Output = new ItemAmount(TropicalItemList.FishRoll, 1),
            Duration = TimeSpan.FromSeconds(20)
        });
        return Task.FromResult(output);
    }
}