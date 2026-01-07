namespace Phase01SimpleDatabase.ImportClasses;
public static class ImportTreeInstanceClass
{
    public static async Task ImportTreesAsync()
    {
        BasicList<TreeInstanceDocument> list = [];
        list.Add(ImportAndyCountryStandard());
        list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        list.Add(ImportCristinaCountryTesting());
        list.Add(ImportAndyTropicalStandard());
        list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        list.Add(ImportCristinaTropicalTesting());
        TreeInstanceDatabase db = new();
        await db.ImportAsync(list);
    }

    private static TreeInstanceDocument ImportAndyCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };

        return new()
        {
            Player = player,
            HowMany = 1
        };
    }
    private static TreeInstanceDocument ImportCristinaCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        return new()
        {
            Player = player,
            HowMany = 2
        };
    }
    private static TreeInstanceDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return new()
        {
            Player = player,
            HowMany = 3
        };
    }
    private static TreeInstanceDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return new()
        {
            Player = player,
            HowMany = 3
        };
    }
    private static TreeInstanceDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return new()
        {
            Player = player,
            HowMany = 1
        };
    }
    private static TreeInstanceDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return new()
        {
            Player = player,
            HowMany = 2
        };
    }
    private static TreeInstanceDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return new()
        {
            Player = player,
            HowMany = 3
        };
    }
    private static TreeInstanceDocument ImportCristinaTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return new()
        {
            Player = player,
            HowMany = 3
        };
    }
}
