namespace Phase01SimpleDatabase.ImportClasses;
public static class ImportWorksiteRecipeClass
{
    public static async Task ImportWorksitesAsync()
    {
        BasicList<WorksiteRecipeDocument> list = [];
        list.AddRange(GetCountryStandardRecipes());
        list.AddRange(GetCountryTestRecipes());
        list.AddRange(GetTropicalStandardRecipes());
        list.AddRange(GetTropicalTestRecipes());
        WorksiteRecipeDatabase db = new();
        await db.ImportAsync(list);
    }
    private static BasicList<WorksiteRecipeDocument> GetCountryStandardRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SampleProduction;
        BasicList<WorksiteRecipeDocument> output = [];
        WorksiteRecipeDocument recipe = new()
        {
            StartText = "Go Foraging!",
            Location = CountryWorksiteListClass.GrandmasGlade,
            Duration = TimeSpan.FromMinutes(15),
            MaximumWorkers = 2,
            Theme = theme,
            Mode = mode
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
            MaximumWorkers = 4,
            Theme = theme,
            Mode = mode
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
        recipe = new()
        {
            StartText = "Go Exploring!",
            Location = CountryWorksiteListClass.Cave,
            Duration = TimeSpan.FromHours(2),
            MaximumWorkers = 6,
            Theme = theme,
            Mode = mode
        };
        recipe.Inputs.Add(CountryItemList.GranillaBars, 2);
        recipe.Inputs.Add(CountryItemList.Blanket, 2);

        benefit = new()
        {
            Guarantee = true,
            Item = CountryItemList.Quartz,
            Quantity = 2
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Padlocks,
            Chance = 0.02
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.BarnNail,
            Chance = 0.03
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Tin,
            Chance = 0.5
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Cooper,
            Chance = 0.07
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);

        return output;
    }
    private static BasicList<WorksiteRecipeDocument> GetCountryTestRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SimpleTesting;
        BasicList<WorksiteRecipeDocument> output = [];
        WorksiteRecipeDocument recipe = new()
        {
            StartText = "Go Foraging!",
            Location = CountryWorksiteListClass.GrandmasGlade,
            Duration = TimeSpan.FromSeconds(8),
            MaximumWorkers = 2,
            Theme = theme,
            Mode = mode
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
            Chance = 0.2,
            Item = CountryItemList.BarnNail
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);
        recipe = new()
        {
            StartText = "Go Fishing!",
            Location = CountryWorksiteListClass.Pond,
            Duration = TimeSpan.FromSeconds(45),
            MaximumWorkers = 4,
            Theme = theme,
            Mode = mode
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
            Chance = 0.1
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.BarnNail,
            Chance = 0.15
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Bass,
            Chance = 0.16
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Mint,
            Chance = 0.2
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);


        recipe = new()
        {
            StartText = "Go Exploring!",
            Location = CountryWorksiteListClass.Cave,
            Duration = TimeSpan.FromSeconds(15),
            MaximumWorkers = 6,
            Theme = theme,
            Mode = mode
        };
        recipe.Inputs.Add(CountryItemList.GranillaBars, 2);
        recipe.Inputs.Add(CountryItemList.Blanket, 2);

        benefit = new()
        {
            Guarantee = true,
            Item = CountryItemList.Quartz,
            Quantity = 2
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Padlocks,
            Chance = 0.1
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.BarnNail,
            Chance = 0.15
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Tin,
            Chance = 0.5
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = CountryItemList.Cooper,
            Chance = 0.2
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);


        return output;
    }
    private static BasicList<WorksiteRecipeDocument> GetTropicalStandardRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SampleProduction;
        BasicList<WorksiteRecipeDocument> output = [];
        WorksiteRecipeDocument recipe = new()
        {
            StartText = "Go snorkeling!",
            Location = TropicalWorksiteListClass.CorelReef,
            Duration = TimeSpan.FromMinutes(15),
            MaximumWorkers = 3,
            Theme = theme,
            Mode = mode
        };
        recipe.Inputs.Add(TropicalItemList.PineappleSmootie, 2);
        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = TropicalItemList.Crab,
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
            MaximumWorkers = 4,
            Theme = theme,
            Mode = mode
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

        recipe = new()
        {
            StartText = "Go spelunking!",
            Location = TropicalWorksiteListClass.SmugglersCave,
            Duration = TimeSpan.FromHours(1),
            MaximumWorkers = 4,
            Theme = theme,
            Mode = mode
        };
        recipe.Inputs.Add(TropicalItemList.TruffleFries, 2);
        recipe.Inputs.Add(TropicalItemList.FriedRice, 2);
        benefit = new()
        {
            Guarantee = true,
            Item = TropicalItemList.IronOre,
            EachWorkerGivesOne = true
        };
        recipe.BaselineBenefits.Add(benefit);


        benefit = new()
        {
            Item = TropicalItemList.BlueCrystal,
            Chance = 0.13
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = TropicalItemList.SilverOre,
            Chance = 0.3
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);

        return output;

    }
    private static BasicList<WorksiteRecipeDocument> GetTropicalTestRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SimpleTesting;
        BasicList<WorksiteRecipeDocument> output = [];
        WorksiteRecipeDocument recipe = new()
        {
            StartText = "Go snorkeling!",
            Location = TropicalWorksiteListClass.CorelReef,
            Duration = TimeSpan.FromMinutes(8),
            MaximumWorkers = 3,
            Theme = theme,
            Mode = mode
        };
        recipe.Inputs.Add(TropicalItemList.PineappleSmootie, 2);
        WorksiteBaselineBenefit benefit = new()
        {
            Guarantee = true,
            Item = TropicalItemList.Crab,
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
            Duration = TimeSpan.FromSeconds(20),
            MaximumWorkers = 4,
            Theme = theme,
            Mode = mode
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

        recipe = new()
        {
            StartText = "Go spelunking!",
            Location = TropicalWorksiteListClass.SmugglersCave,
            Duration = TimeSpan.FromHours(12),
            MaximumWorkers = 4,
            Theme = theme,
            Mode = mode
        };
        recipe.Inputs.Add(TropicalItemList.TruffleFries, 2);
        recipe.Inputs.Add(TropicalItemList.FriedRice, 2);
        benefit = new()
        {
            Guarantee = true,
            Item = TropicalItemList.IronOre,
            EachWorkerGivesOne = true
        };
        recipe.BaselineBenefits.Add(benefit);


        benefit = new()
        {
            Item = TropicalItemList.BlueCrystal,
            Chance = 0.13
        };
        recipe.BaselineBenefits.Add(benefit);
        benefit = new()
        {
            Item = TropicalItemList.SilverOre,
            Chance = 0.3
        };
        recipe.BaselineBenefits.Add(benefit);
        output.Add(recipe);


        return output;

    }
}
