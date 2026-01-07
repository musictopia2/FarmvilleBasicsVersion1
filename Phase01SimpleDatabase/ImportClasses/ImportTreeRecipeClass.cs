namespace Phase01SimpleDatabase.ImportClasses;
public static class ImportTreeRecipeClass
{
    public static async Task ImportTreesAsync()
    {
        BasicList<TreeRecipeDocument> list = [];
        list.AddRange(GetCountryStandardRecipes());
        list.AddRange(GetCountryTestRecipes());
        list.AddRange(GetTropicalStandardRecipes());
        list.AddRange(GetTropicalTestRecipes());
        TreeRecipeDatabase db = new();
        await db.ImportAsync(list);
    }
    private static BasicList<TreeRecipeDocument> GetCountryStandardRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SampleProduction;
        BasicList<TreeRecipeDocument> output = [];
        TreeRecipeDocument tree = new()
        {
            TreeName = CountryTreeListClass.Apple,
            Item = CountryItemList.Apples,
            ProductionTimeForEach = TimeSpan.FromSeconds(10),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = CountryTreeListClass.Peach,
            Item = CountryItemList.Peaches,
            ProductionTimeForEach = TimeSpan.FromHours(1),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);
        return output;
    }
    private static BasicList<TreeRecipeDocument> GetCountryTestRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SimpleTesting;
        BasicList<TreeRecipeDocument> output = [];
        TreeRecipeDocument tree = new()
        {
            TreeName = CountryTreeListClass.Apple,
            Item = CountryItemList.Apples,
            ProductionTimeForEach = TimeSpan.FromSeconds(2),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = CountryTreeListClass.Peach,
            Item = CountryItemList.Peaches,
            ProductionTimeForEach = TimeSpan.FromSeconds(30),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);
        return output;
    }
    private static BasicList<TreeRecipeDocument> GetTropicalStandardRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SampleProduction;
        BasicList<TreeRecipeDocument> output = [];
        TreeRecipeDocument tree = new()
        {
            TreeName = TropicalTreeListClass.Coconut,
            Item = TropicalItemList.Coconut,
            ProductionTimeForEach = TimeSpan.FromMinutes(2),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = TropicalTreeListClass.Lime,
            Item = TropicalItemList.Lime,
            ProductionTimeForEach = TimeSpan.FromMinutes(45),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);

        return output;

    }
    private static BasicList<TreeRecipeDocument> GetTropicalTestRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SimpleTesting;
        BasicList<TreeRecipeDocument> output = [];
        TreeRecipeDocument tree = new()
        {
            TreeName = TropicalTreeListClass.Coconut,
            Item = TropicalItemList.Coconut,
            ProductionTimeForEach = TimeSpan.FromSeconds(3),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);
        tree = new()
        {
            TreeName = TropicalTreeListClass.Lime,
            Item = TropicalItemList.Lime,
            ProductionTimeForEach = TimeSpan.FromSeconds(20),
            Theme = theme,
            Mode = mode
        };
        output.Add(tree);

        return output;

    }

}