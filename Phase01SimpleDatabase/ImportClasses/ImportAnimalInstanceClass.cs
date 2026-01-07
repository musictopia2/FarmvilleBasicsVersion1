namespace Phase01SimpleDatabase.ImportClasses;
public static class ImportAnimalInstanceClass
{
    public static async Task ImportAnimalsAsync()
    {
        BasicList<AnimalInstanceDocument> list = [];
        list.Add(ImportAndyCountryStandard());
        list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        list.Add(ImportCristinaCountryTesting());
        list.Add(ImportAndyTropicalStandard());
        list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        list.Add(ImportCristinaTropicalTesting());
        AnimalInstanceDatabase db = new();
        await db.ImportAsync(list);
    }

    private static AnimalInstanceDocument ImportAndyCountryStandard()
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
    private static AnimalInstanceDocument ImportCristinaCountryStandard()
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
    private static AnimalInstanceDocument ImportAndyCountryTesting()
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
    private static AnimalInstanceDocument ImportCristinaCountryTesting()
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
    private static AnimalInstanceDocument ImportAndyTropicalStandard()
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
    private static AnimalInstanceDocument ImportCristinaTropicalStandard()
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
    private static AnimalInstanceDocument ImportAndyTropicalTesting()
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
    private static AnimalInstanceDocument ImportCristinaTropicalTesting()
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