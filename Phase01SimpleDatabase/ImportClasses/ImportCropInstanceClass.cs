namespace Phase01SimpleDatabase.ImportClasses;
public static class ImportCropInstanceClass
{
    public static async Task ImportCropsAsync()
    {
        BasicList<CropInstanceDocument> list = [];
        list.Add(ImportAndyCountryStandard());
        list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        list.Add(ImportCristinaCountryTesting());
        list.Add(ImportAndyTropicalStandard());
        list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        list.Add(ImportCristinaTropicalTesting());
        CropInstanceDatabase db = new();
        await db.ImportAsync(list);
    }

    private static CropInstanceDocument ImportAndyCountryStandard()
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
            HowMany = 8
        };
    }
    private static CropInstanceDocument ImportCristinaCountryStandard()
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
            HowMany = 10
        };
    }
    private static CropInstanceDocument ImportAndyCountryTesting()
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
            HowMany = 26
        };
    }
    private static CropInstanceDocument ImportCristinaCountryTesting()
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
            HowMany = 30
        };
    }
    private static CropInstanceDocument ImportAndyTropicalStandard()
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
            HowMany = 8
        };
    }
    private static CropInstanceDocument ImportCristinaTropicalStandard()
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
            HowMany = 8
        };
    }
    private static CropInstanceDocument ImportAndyTropicalTesting()
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
            HowMany = 26
        };

    }
    private static CropInstanceDocument ImportCristinaTropicalTesting()
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
            HowMany = 30
        };
    }
}