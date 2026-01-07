namespace Phase04CollectionProcesses.Data.Workshops;
public class TropicalStandardWorkshopRecipesRegistry : IWorkshopRegistry
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
            Duration = TimeSpan.FromMinutes(1)
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
            Duration = TimeSpan.FromMinutes(5)
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
            Duration = TimeSpan.FromSeconds(30)
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
            Duration = TimeSpan.FromMinutes(3)
        });
        return Task.FromResult(output);
    }
}