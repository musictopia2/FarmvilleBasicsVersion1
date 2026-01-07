namespace Phase03ConcurrentPlayerSessions.Data.Workshops;
public class TropicalTestWorkshopRecipesRegistry : IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> IWorkshopRegistry.GetWorkshopRecipesAsync()
    {
        BasicList<WorkshopRecipe> output = [];
        output.Add(new WorkshopRecipe
        {
            Item = TropicalItemList.PineappleSmootie,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs = { [TropicalItemList.Pineapple] = 3 },
            Output = new ItemAmount(TropicalItemList.PineappleSmootie, 1),
            Duration = TimeSpan.FromSeconds(10)
        });

        output.Add(new WorkshopRecipe
        {
            Item = TropicalItemList.PinaColada,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs =
            { 
                [TropicalItemList.Coconut] = 3 ,
                [TropicalItemList.Pineapple] = 2
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