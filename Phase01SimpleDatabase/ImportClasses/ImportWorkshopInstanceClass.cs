namespace Phase01SimpleDatabase.ImportClasses;
internal static class ImportWorkshopInstanceClass
{
    public static async Task ImportWorkshopsAsync()
    {
        BasicList<WorkshopInstanceDocument> list = [];
        list.Add(ImportAndyCountryStandard());
        list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        list.Add(ImportCristinaCountryTesting());
        list.Add(ImportAndyTropicalStandard());
        list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        list.Add(ImportCristinaTropicalTesting());
        WorkshopInstanceDatabase db = new();
        await db.ImportAsync(list);
    }

    private static WorkshopInstanceDocument ImportAndyCountryStandard()
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
    private static WorkshopInstanceDocument ImportCristinaCountryStandard()
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
            HowMany = 1
        };
    }
    private static WorkshopInstanceDocument ImportAndyCountryTesting()
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
            HowMany = 2
        };
    }
    private static WorkshopInstanceDocument ImportCristinaCountryTesting()
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
            HowMany = 2
        };
    }
    private static WorkshopInstanceDocument ImportAndyTropicalStandard()
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
    private static WorkshopInstanceDocument ImportCristinaTropicalStandard()
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
            HowMany = 1
        };
    }
    private static WorkshopInstanceDocument ImportAndyTropicalTesting()
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
            HowMany = 2
        };
    }
    private static WorkshopInstanceDocument ImportCristinaTropicalTesting()
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
            HowMany = 2
        };
    }
}
