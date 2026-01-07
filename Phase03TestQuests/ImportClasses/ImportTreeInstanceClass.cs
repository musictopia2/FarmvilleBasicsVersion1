namespace Phase03TestQuests.ImportClasses;
public static class ImportTreeInstanceClass
{
    private static BasicList<TreeRecipeDocument> _recipes = [];
    public static async Task ImportTreesAsync()
    {
        TreeRecipeDatabase temp = new();
        _recipes = await temp.GetRecipesAsync();
        if(_recipes.Count == 0)
        {
            throw new CustomBasicException("No recipes");
        }
        BasicList<TreeInstanceDocument> list = [];
        //list.Add(ImportAndyCountryStandard());
        //list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        //list.Add(ImportCristinaCountryTesting());
        //list.Add(ImportAndyTropicalStandard());
        //list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        //list.Add(ImportCristinaTropicalTesting());
        TreeInstanceDatabase db = new();
        await db.ImportAsync(list);
    }

    private static TreeInstanceDocument GetInstance(int maxs, PlayerState player)
    {
        BasicList<TreeAutoResumeModel> list = [];
        var updates = _recipes.Where(x => x.Mode == player.SessionMode && x.Theme == player.FarmTheme).ToBasicList();
        updates.ForEach(recipe =>
        {
            maxs.Times(x =>
            {
                list.Add(new()
                { 
                    TreeName = recipe.TreeName
                });
            });
        });


        return new()
        {
            Player = player,
            Trees = list,
        };
    }
    private static TreeInstanceDocument ImportAndyCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
        
    }
    private static TreeInstanceDocument ImportCristinaCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(2, player);
        
    }
    private static TreeInstanceDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(1, player);
        
    }
    private static TreeInstanceDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(3, player);
        
    }
    private static TreeInstanceDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
        
    }
    private static TreeInstanceDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(2, player);
    }
    private static TreeInstanceDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(1, player);  
    }
    private static TreeInstanceDocument ImportCristinaTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(3, player);
    }
}