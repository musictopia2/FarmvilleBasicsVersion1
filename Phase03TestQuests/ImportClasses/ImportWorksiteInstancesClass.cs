namespace Phase03TestQuests.ImportClasses;
public static class ImportWorksiteInstancesClass
{
    private static BasicList<WorksiteRecipeDocument> _recipes = [];
    public static async Task ImportWorksitesAsync()
    {
        WorksiteRecipeDatabase temp = new();
        _recipes = await temp.GetRecipesAsync();
        if (_recipes.Count == 0)
        {
            throw new CustomBasicException("No recipes");
        }
        BasicList<WorksiteInstanceDocument> list = [];
        //list.Add(ImportAndyCountryStandard());
        //list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        //list.Add(ImportCristinaCountryTesting());
        //list.Add(ImportAndyTropicalStandard());
        //list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        //list.Add(ImportCristinaTropicalTesting());
        WorksiteInstanceDatabase db = new();
        await db.ImportAsync(list);
    }
    private static WorksiteInstanceDocument GetInstance(PlayerState player)
    {
        BasicList<WorksiteAutoResumeModel> list = [];
        var worksites = _recipes
            .Where(x => x.Mode == player.SessionMode && x.Theme == player.FarmTheme)
            .Select(x => x.Location);

        foreach (var worksite in worksites)
        {
            list.Add(new WorksiteAutoResumeModel
            {
                Name = worksite
            });
        }
        return new()
        {
            Player = player,
            Worksites = list,
        };
    }


    private static WorksiteInstanceDocument ImportAndyCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportCristinaCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(player);
    }
    private static WorksiteInstanceDocument ImportCristinaTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(player);
    }




}