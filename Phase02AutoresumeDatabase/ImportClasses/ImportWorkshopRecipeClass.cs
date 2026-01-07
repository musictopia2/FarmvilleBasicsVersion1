namespace Phase02AutoresumeDatabase.ImportClasses;

public static class ImportWorkshopRecipeClass
{
    public static async Task ImportWorkshopsAsync()
    {
        BasicList<WorkshopRecipeDocument> list = [];
        list.AddRange(GetCountryStandardRecipes());
        list.AddRange(GetCountryTestRecipes());
        list.AddRange(GetTropicalStandardRecipes());
        list.AddRange(GetTropicalTestRecipes());
        WorkshopRecipeDatabase db = new();
        await db.ImportAsync(list);
    }
    private static BasicList<WorkshopRecipeDocument> GetCountryStandardRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SampleProduction;
        BasicList<WorkshopRecipeDocument> output = [];


        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Flour,
            BuildingName = CountryWorkshopList.Windmill,
            Inputs = { [CountryItemList.Wheat] = 3 },
            Output = new ItemAmount(CountryItemList.Flour, 1),
            Duration = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Sugar,
            BuildingName = CountryWorkshopList.Windmill,
            Inputs = { [CountryItemList.Corn] = 2 },
            Output = new ItemAmount(CountryItemList.Sugar, 1),
            Duration = TimeSpan.FromMinutes(2),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Biscuit,
            BuildingName = CountryWorkshopList.PastryOven,
            Inputs =
            {
                [CountryItemList.Flour] = 1,
                [CountryItemList.Milk] = 1
            },
            Output = new ItemAmount(CountryItemList.Biscuit, 1),
            Duration = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.ApplePie,
            BuildingName = CountryWorkshopList.PastryOven,
            Inputs =
            {
                [CountryItemList.Flour] = 2,
                [CountryItemList.Apple] = 4,
                [CountryItemList.Milk] = 1
            },
            Output = new ItemAmount(CountryItemList.ApplePie, 1),
            Duration = TimeSpan.FromMinutes(1),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.FarmersSoup,
            BuildingName = CountryWorkshopList.StovetopOven,
            Inputs =
            {
                [CountryItemList.GoatMilk] = 8,
                [CountryItemList.Carrot] = 10,
                [CountryItemList.Tomato] = 4
            },
            Output = new ItemAmount(CountryItemList.FarmersSoup, 1),
            Duration = TimeSpan.FromMinutes(3.5),
            Theme = theme,
            Mode = mode
        });
        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.GranolaBar,
            BuildingName = CountryWorkshopList.StovetopOven,
            Inputs =
            {
                [CountryItemList.HoneyComb] = 1,
                [CountryItemList.Wheat] = 5,
                [CountryItemList.Strawberry] = 4
            },
            Output = new ItemAmount(CountryItemList.FarmersSoup, 1),
            Duration = TimeSpan.FromMinutes(7),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Trousers,
            BuildingName = CountryWorkshopList.Loom,
            Inputs =
            {
                [CountryItemList.Wool] = 6
            },
            Output = new ItemAmount(CountryItemList.Trousers, 1),
            Duration = TimeSpan.FromMinutes(20),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Blanket,
            BuildingName = CountryWorkshopList.Loom,
            Inputs =
            {
                [CountryItemList.Wool] = 3
            },
            Output = new ItemAmount(CountryItemList.Blanket, 1),
            Duration = TimeSpan.FromMinutes(10),
            Theme = theme,
            Mode = mode
        });
        

        return output;
    }
    private static BasicList<WorkshopRecipeDocument> GetCountryTestRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SimpleTesting;
        BasicList<WorkshopRecipeDocument> output = [];

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Flour,
            BuildingName = CountryWorkshopList.Windmill,
            Inputs = { [CountryItemList.Wheat] = 3 },
            Output = new ItemAmount(CountryItemList.Flour, 1),
            Duration = TimeSpan.FromSeconds(2),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Sugar,
            BuildingName = CountryWorkshopList.Windmill,
            Inputs = { [CountryItemList.Corn] = 2 },
            Output = new ItemAmount(CountryItemList.Sugar, 1),
            Duration = TimeSpan.FromSeconds(4),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Biscuit,
            BuildingName = CountryWorkshopList.PastryOven,
            Inputs =
            {
                [CountryItemList.Flour] = 1,
                [CountryItemList.Milk] = 1
            },
            Output = new ItemAmount(CountryItemList.Biscuit, 1),
            Duration = TimeSpan.FromSeconds(2),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.ApplePie,
            BuildingName = CountryWorkshopList.PastryOven,
            Inputs =
            {
                [CountryItemList.Flour] = 2,
                [CountryItemList.Apple] = 4,
                [CountryItemList.Milk] = 1
            },
            Output = new ItemAmount(CountryItemList.ApplePie, 1),
            Duration = TimeSpan.FromSeconds(4),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.FarmersSoup,
            BuildingName = CountryWorkshopList.StovetopOven,
            Inputs =
            {
                [CountryItemList.GoatMilk] = 8,
                [CountryItemList.Carrot] = 10,
                [CountryItemList.Tomato] = 4
            },
            Output = new ItemAmount(CountryItemList.FarmersSoup, 1),
            Duration = TimeSpan.FromSeconds(7),
            Theme = theme,
            Mode = mode
        });
        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.GranolaBar,
            BuildingName = CountryWorkshopList.StovetopOven,
            Inputs =
            {
                [CountryItemList.HoneyComb] = 1,
                [CountryItemList.Wheat] = 5,
                [CountryItemList.Strawberry] = 4
            },
            Output = new ItemAmount(CountryItemList.FarmersSoup, 1),
            Duration = TimeSpan.FromSeconds(10),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Trousers,
            BuildingName = CountryWorkshopList.Loom,
            Inputs =
            {
                [CountryItemList.Wool] = 3
            },
            Output = new ItemAmount(CountryItemList.Trousers, 1),
            Duration = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = CountryItemList.Blanket,
            BuildingName = CountryWorkshopList.Loom,
            Inputs =
            {
                [CountryItemList.Wool] = 3
            },
            Output = new ItemAmount(CountryItemList.Blanket, 1),
            Duration = TimeSpan.FromSeconds(12),
            Theme = theme,
            Mode = mode
        });


        return output;
    }
    private static BasicList<WorkshopRecipeDocument> GetTropicalStandardRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SampleProduction;
        BasicList<WorkshopRecipeDocument> output = [];

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.PineappleSmoothie,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs = { [TropicalItemList.Pineapple] = 3 },
            Output = new ItemAmount(TropicalItemList.PineappleSmoothie, 1),
            Duration = TimeSpan.FromMinutes(1),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.PinaColada,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs =
            {
                [TropicalItemList.Coconut] = 3 ,
                [TropicalItemList.Pineapple] = 2
            },
            Output = new ItemAmount(TropicalItemList.PinaColada, 1),
            Duration = TimeSpan.FromMinutes(5),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.SteamedRice,
            BuildingName = TropicalWorkshopList.SushiStand,
            Inputs =
            {
                [TropicalItemList.Rice] = 2,
            },
            Output = new ItemAmount(TropicalItemList.SteamedRice, 1),
            Duration = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.FishRoll,
            BuildingName = TropicalWorkshopList.SushiStand,
            Inputs =
            {
                [TropicalItemList.Fish] = 2,
                [TropicalItemList.SteamedRice] = 1
            },
            Output = new ItemAmount(TropicalItemList.FishRoll, 1),
            Duration = TimeSpan.FromMinutes(3),
            Theme = theme,
            Mode = mode
        });


        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.GrilledCrab,
            BuildingName = TropicalWorkshopList.Grill,
            Inputs =
            {
                [TropicalItemList.Crab] = 1,
            },
            Output = new ItemAmount(TropicalItemList.GrilledCrab, 1),
            Duration = TimeSpan.FromMinutes(3),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.FriedRice,
            BuildingName = TropicalWorkshopList.Grill,
            Inputs =
            {
                [TropicalItemList.Egg] = 2,
                [TropicalItemList.SteamedRice] = 1,
                [TropicalItemList.Pineapple] = 1
            },
            Output = new ItemAmount(TropicalItemList.FriedRice, 1),
            Duration = TimeSpan.FromMinutes(8),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.Ceviche,
            BuildingName = TropicalWorkshopList.BeachfrontKitchen,
            Inputs =
            {
                [TropicalItemList.Fish] = 3 ,
                [TropicalItemList.Coconut] = 2,
                [TropicalItemList.Lime] = 2
            },
            Output = new ItemAmount(TropicalItemList.Ceviche, 1),
            Duration = TimeSpan.FromMinutes(10),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.TruffleFries,
            BuildingName = TropicalWorkshopList.BeachfrontKitchen,
            Inputs =
            {
                [TropicalItemList.Tapioca] = 2,
                [TropicalItemList.Mushroom] = 2
            },
            Output = new ItemAmount(TropicalItemList.TruffleFries, 1),
            Duration = TimeSpan.FromMinutes(20),
            Theme = theme,
            Mode = mode
        });

        



        return output;

    }
    private static BasicList<WorkshopRecipeDocument> GetTropicalTestRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SimpleTesting;
        BasicList<WorkshopRecipeDocument> output = [];
        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.PineappleSmoothie,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs = { [TropicalItemList.Pineapple] = 3 },
            Output = new ItemAmount(TropicalItemList.PineappleSmoothie, 1),
            Duration = TimeSpan.FromSeconds(3),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.PinaColada,
            BuildingName = TropicalWorkshopList.HuluHit,
            Inputs =
            {
                [TropicalItemList.Coconut] = 3 ,
                [TropicalItemList.Pineapple] = 2
            },
            Output = new ItemAmount(TropicalItemList.PinaColada, 1),
            Duration = TimeSpan.FromSeconds(6),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.SteamedRice,
            BuildingName = TropicalWorkshopList.SushiStand,
            Inputs =
            {
                [TropicalItemList.Rice] = 2,
            },
            Output = new ItemAmount(TropicalItemList.SteamedRice, 1),
            Duration = TimeSpan.FromSeconds(2),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.FishRoll,
            BuildingName = TropicalWorkshopList.SushiStand,
            Inputs =
            {
                [TropicalItemList.Fish] = 2,
                [TropicalItemList.SteamedRice] = 1
            },
            Output = new ItemAmount(TropicalItemList.FishRoll, 1),
            Duration = TimeSpan.FromSeconds(4),
            Theme = theme,
            Mode = mode
        });


        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.GrilledCrab,
            BuildingName = TropicalWorkshopList.Grill,
            Inputs =
            {
                [TropicalItemList.Crab] = 1,
            },
            Output = new ItemAmount(TropicalItemList.GrilledCrab, 1),
            Duration = TimeSpan.FromSeconds(4),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.FriedRice,
            BuildingName = TropicalWorkshopList.Grill,
            Inputs =
            {
                [TropicalItemList.Egg] = 2,
                [TropicalItemList.SteamedRice] = 1,
                [TropicalItemList.Pineapple] = 1
            },
            Output = new ItemAmount(TropicalItemList.FriedRice, 1),
            Duration = TimeSpan.FromSeconds(6),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.Ceviche,
            BuildingName = TropicalWorkshopList.BeachfrontKitchen,
            Inputs =
            {
                [TropicalItemList.Fish] = 3 ,
                [TropicalItemList.Coconut] = 2,
                [TropicalItemList.Lime] = 2
            },
            Output = new ItemAmount(TropicalItemList.Ceviche, 1),
            Duration = TimeSpan.FromSeconds(7),
            Theme = theme,
            Mode = mode
        });

        output.Add(new WorkshopRecipeDocument
        {
            Item = TropicalItemList.TruffleFries,
            BuildingName = TropicalWorkshopList.BeachfrontKitchen,
            Inputs =
            {
                [TropicalItemList.Tapioca] = 2,
                [TropicalItemList.Mushroom] = 2
            },
            Output = new ItemAmount(TropicalItemList.TruffleFries, 1),
            Duration = TimeSpan.FromSeconds(10),
            Theme = theme,
            Mode = mode
        });


        return output;

    }
}