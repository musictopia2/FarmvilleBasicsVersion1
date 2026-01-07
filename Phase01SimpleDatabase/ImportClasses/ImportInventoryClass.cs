
namespace Phase01SimpleDatabase.ImportClasses;
public static class ImportInventoryClass
{
    public static async Task ImportBeginningInventoryAmountsAsync()
    {
        BasicList<InventoryDocument> list = [];
        list.Add(ImportAndyCountryStandard());
        list.Add(ImportCristinaCountryStandard());
        list.Add(ImportAndyCountryTesting());
        list.Add(ImportCristinaCountryTesting());
        list.Add(ImportAndyTropicalStandard());
        list.Add(ImportCristinaTropicalStandard());
        list.Add(ImportAndyTropicalTesting());
        list.Add(ImportCristinaTropicalTesting());
        InventoryDatabase db = new();
        await db.ImportAsync(list);
    }

    private static InventoryDocument ImportAndyCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        int amount = 10;
        Dictionary<string, int> amounts = new()
        {
            [CountryItemList.Wheat] = amount,
            [CountryItemList.Corn] = amount,
            [CountryItemList.Honey] = amount,
            [CountryItemList.Tomato] = amount,
            [CountryItemList.Strawberry] = amount,
            [CountryItemList.Carrot] = amount,
            [CountryItemList.Milk] = 1,
            [CountryItemList.GoatMilk] = 2,
            [CountryItemList.Wool] = 3
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
    private static InventoryDocument ImportCristinaCountryStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SampleProduction
        };
        int amount = 20;
        Dictionary<string, int> amounts = new()
        {
            [CountryItemList.Wheat] = amount,
            [CountryItemList.Corn] = amount,
            [CountryItemList.Honey] = amount,
            [CountryItemList.Tomato] = amount,
            [CountryItemList.Strawberry] = amount,
            [CountryItemList.Carrot] = amount,
            [CountryItemList.Milk] = 1,
            [CountryItemList.GoatMilk] = 2,
            [CountryItemList.Wool] = 3
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
    private static InventoryDocument ImportAndyCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        int amount = 30;
        Dictionary<string, int> amounts = new()
        {
            [CountryItemList.Wheat] = amount,
            [CountryItemList.Corn] = amount,
            [CountryItemList.Honey] = amount,
            [CountryItemList.Tomato] = amount,
            [CountryItemList.Strawberry] = amount,
            [CountryItemList.Carrot] = amount,
            [CountryItemList.Milk] = 6,
            [CountryItemList.GoatMilk] = 10,
            [CountryItemList.Wool] = 12
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
    private static InventoryDocument ImportCristinaCountryTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Country,
            SessionMode = SessionModeList.SimpleTesting
        };
        int amount = 40;
        Dictionary<string, int> amounts = new()
        {
            [CountryItemList.Wheat] = amount,
            [CountryItemList.Corn] = amount,
            [CountryItemList.Honey] = amount,
            [CountryItemList.Tomato] = amount,
            [CountryItemList.Strawberry] = amount,
            [CountryItemList.Carrot] = amount,
            [CountryItemList.Milk] = 10,
            [CountryItemList.GoatMilk] = 14,
            [CountryItemList.Wool] = 16
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
    private static InventoryDocument ImportAndyTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        int amount = 10;
        int trees = 4;
        Dictionary<string, int> amounts = new()
        {
            [TropicalItemList.Pineapple] = amount,
            [TropicalItemList.Rice] = amount,
            [TropicalItemList.Lime] = trees,
            [TropicalItemList.Coconut] = trees,
            [TropicalItemList.Fish] = 2,
            [TropicalItemList.Tapioca] = amount,
            [TropicalItemList.Mushroom] = 1,
            [TropicalItemList.Egg] = 1
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
    private static InventoryDocument ImportCristinaTropicalStandard()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SampleProduction
        };
        int amount = 12;
        int trees = 6;
        Dictionary<string, int> amounts = new()
        {
            [TropicalItemList.Pineapple] = amount,
            [TropicalItemList.Rice] = amount,
            [TropicalItemList.Lime] = trees,
            [TropicalItemList.Coconut] = trees,
            [TropicalItemList.Fish] = 2,
            [TropicalItemList.Tapioca] = amount,
            [TropicalItemList.Mushroom] = 1,
            [TropicalItemList.Egg] = 1
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
    private static InventoryDocument ImportAndyTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player1,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        int amount = 20;
        int trees = 8;
        Dictionary<string, int> amounts = new()
        {
            [TropicalItemList.Pineapple] = amount,
            [TropicalItemList.Rice] = amount,
            [TropicalItemList.Lime] = trees,
            [TropicalItemList.Coconut] = trees,
            [TropicalItemList.Fish] = 4,
            [TropicalItemList.Tapioca] = amount,
            [TropicalItemList.Mushroom] = 2,
            [TropicalItemList.Egg] = 2
        };
        return new()
        {
            Player = player,
            List = amounts
        };
        
    }
    private static InventoryDocument ImportCristinaTropicalTesting()
    {
        PlayerState player = new()
        {
            PlayerName = PlayerList.Player2,
            FarmTheme = FarmThemeList.Tropical,
            SessionMode = SessionModeList.SimpleTesting
        };
        int amount = 30;
        int trees = 10;
        Dictionary<string, int> amounts = new()
        {
            [TropicalItemList.Pineapple] = amount,
            [TropicalItemList.Rice] = amount,
            [TropicalItemList.Lime] = trees,
            [TropicalItemList.Coconut] = trees,
            [TropicalItemList.Fish] = 6,
            [TropicalItemList.Tapioca] = amount,
            [TropicalItemList.Mushroom] = 3,
            [TropicalItemList.Egg] = 3
        };
        return new()
        {
            Player = player,
            List = amounts
        };
    }
}