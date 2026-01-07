namespace Phase02AutoresumeDatabase.ImportClasses;
public static class ImportCropRecipeClass
{
    public static async Task ImportCropsAsync()
    {
        BasicList<CropRecipeDocument> list = [];
        list.AddRange(GetCountryStandardRecipes());
        list.AddRange(GetCountryTestRecipes());
        list.AddRange(GetTropicalStandardRecipes());
        list.AddRange(GetTropicalTestRecipes());
        CropRecipeDatabase db = new();
        await db.ImportAsync(list);
    }
    private static BasicList<CropRecipeDocument> GetCountryStandardRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SampleProduction;
        BasicList<CropRecipeDocument> output = [];
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Wheat,
            Duration = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Corn,
            Duration = TimeSpan.FromMinutes(2),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.HoneyComb,
            Duration = TimeSpan.FromMinutes(45),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Strawberry,
            Duration = TimeSpan.FromHours(1),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Tomato,
            Duration = TimeSpan.FromMinutes(10),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Carrot,
            Duration = TimeSpan.FromMinutes(4),
            Theme = theme,
            Mode = mode
        });
        return output;
    }
    private static BasicList<CropRecipeDocument> GetCountryTestRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SimpleTesting;
        BasicList<CropRecipeDocument> output = [];
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Wheat,
            Duration = TimeSpan.FromSeconds(2),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Corn,
            Duration = TimeSpan.FromSeconds(5),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.HoneyComb,
            Duration = TimeSpan.FromSeconds(20),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Strawberry,
            Duration = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Tomato,
            Duration = TimeSpan.FromSeconds(10),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = CountryItemList.Carrot,
            Duration = TimeSpan.FromSeconds(6),
            Theme = theme,
            Mode = mode
        });
        return output;
    }
    private static BasicList<CropRecipeDocument> GetTropicalStandardRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SampleProduction;
        BasicList<CropRecipeDocument> output = [];
        output.Add(new CropRecipeDocument
        {
            Item = TropicalItemList.Pineapple,
            Duration = TimeSpan.FromSeconds(45),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = TropicalItemList.Rice,
            Duration = TimeSpan.FromMinutes(1),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = TropicalItemList.Tapioca,
            Duration = TimeSpan.FromMinutes(20),
            Theme = theme,
            Mode = mode
        });

        return output;

    }

    private static BasicList<CropRecipeDocument> GetTropicalTestRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SampleProduction;
        BasicList<CropRecipeDocument> output = [];
        output.Add(new CropRecipeDocument
        {
            Item = TropicalItemList.Pineapple,
            Duration = TimeSpan.FromSeconds(2),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = TropicalItemList.Rice,
            Duration = TimeSpan.FromSeconds(4),
            Theme = theme,
            Mode = mode
        });
        output.Add(new CropRecipeDocument
        {
            Item = TropicalItemList.Tapioca,
            Duration = TimeSpan.FromSeconds(9),
            Theme = theme,
            Mode = mode
        });

        return output;

    }



}