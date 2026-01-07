namespace Phase03TestQuests.ImportClasses;
internal static class ImportWorkshopInstanceClass
{
    private static BasicList<WorkshopRecipeDocument> _recipes = [];
    public static async Task ImportWorkshopsAsync()
    {
        WorkshopRecipeDatabase temp = new();
        _recipes = await temp.GetRecipesAsync();
        if (_recipes.Count == 0)
        {
            throw new CustomBasicException("No recipes");
        }
        BasicList<WorkshopInstanceDocument> list = [];
        //list.Add(ImportAndyCountryStandard());
        //list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        //list.Add(ImportCristinaCountryTesting());
        //list.Add(ImportAndyTropicalStandard());
        //list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        //list.Add(ImportCristinaTropicalTesting());
        WorkshopInstanceDatabase db = new();
        await db.ImportAsync(list);
    }
    private static WorkshopInstanceDocument GetInstance(int maxs, PlayerState player)
    {
        BasicList<WorkshopAutoResumeModel> list = [];
        var buildings = _recipes
            .Where(x => x.Mode == player.SessionMode && x.Theme == player.FarmTheme)
            .Select(x => x.BuildingName)
            .Distinct();

        foreach (var building in buildings)
        {
            maxs.Times(_ =>
            {
                list.Add(new WorkshopAutoResumeModel
                {
                    Name = building
                });
            });
        }
        return new()
        {
            Player = player,
            Workshops = list,
        };
    }


    private static WorkshopInstanceDocument ImportAndyCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static WorkshopInstanceDocument ImportCristinaCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static WorkshopInstanceDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
    private static WorkshopInstanceDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
    private static WorkshopInstanceDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static WorkshopInstanceDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static WorkshopInstanceDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
    private static WorkshopInstanceDocument ImportCristinaTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
}
