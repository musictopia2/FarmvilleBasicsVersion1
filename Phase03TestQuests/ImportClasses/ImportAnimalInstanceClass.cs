namespace Phase03TestQuests.ImportClasses;
public static class ImportAnimalInstanceClass
{
    private static BasicList<AnimalRecipeDocument> _recipes = [];
    public static async Task ImportAnimalsAsync()
    {
        AnimalRecipeDatabase temp = new();
        _recipes = await temp.GetRecipesAsync();
        if (_recipes.Count == 0)
        {
            throw new CustomBasicException("No recipes");
        }
        BasicList<AnimalInstanceDocument> list = [];
        //list.Add(ImportAndyCountryStandard());
        //list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        //list.Add(ImportCristinaCountryTesting());
        //list.Add(ImportAndyTropicalStandard());
        //list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        //list.Add(ImportCristinaTropicalTesting());
        AnimalInstanceDatabase db = new();
        await db.ImportAsync(list);
    }
    private static AnimalInstanceDocument GetInstance(int maxs, PlayerState player)
    {
        BasicList<AnimalAutoResumeModel> list = [];
        var updates = _recipes.Where(x => x.Mode == player.SessionMode && x.Theme == player.FarmTheme).ToBasicList();
        updates.ForEach(recipe =>
        {
            maxs.Times(x =>
            {
                list.Add(new()
                {
                    Name = recipe.Animal,
                    ProductionOptionsAllowed = recipe.Options.Count
                });
            });
        });
        return new()
        {
            Player = player,
            Animals = list,
        };
    }
    private static AnimalInstanceDocument ImportAndyCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static AnimalInstanceDocument ImportCristinaCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static AnimalInstanceDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
    private static AnimalInstanceDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
    private static AnimalInstanceDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static AnimalInstanceDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(1, player);
    }
    private static AnimalInstanceDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(2, player);
    }
    private static AnimalInstanceDocument ImportCristinaTropicalTesting()
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