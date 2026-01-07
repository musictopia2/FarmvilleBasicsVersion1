namespace Phase03TestQuests.ImportClasses;
public static class ImportCropInstanceClass
{
    public static async Task ImportCropsAsync()
    {
        BasicList<CropInstanceDocument> list = [];
        //list.Add(ImportAndyCountryStandard());
        //list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        //list.Add(ImportCristinaCountryTesting());
        //list.Add(ImportAndyTropicalStandard());
        //list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        //list.Add(ImportCristinaTropicalTesting());
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
        return GetInstance(8, player);
        
    }

    private static CropInstanceDocument GetInstance(int maxs, PlayerState player)
    {
        BasicList<CropAutoResumeModel> slots = [];

        maxs.Times(x =>
        {
            slots.Add(new());
        });

        return new()
        {
            Player = player,
            Slots = slots,
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
        return GetInstance(10, player);
        
    }
    private static CropInstanceDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(15, player);
       
    }
    private static CropInstanceDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(30, player);
        
    }
    private static CropInstanceDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(8, player);
        
    }
    private static CropInstanceDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        return GetInstance(8, player);
        
    }
    private static CropInstanceDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(16, player);
        
    }
    private static CropInstanceDocument ImportCristinaTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        return GetInstance(30, player);
        
    }
}