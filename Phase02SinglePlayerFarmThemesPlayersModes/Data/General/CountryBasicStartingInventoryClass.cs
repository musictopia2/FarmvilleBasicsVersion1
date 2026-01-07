namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.General;
public class CountryBasicStartingInventoryClass(PlayerState player) : IStartingInventoryProvider
{
    Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync()
    {
        int amount;
        int wheatAmount = 6;
        amount = 6;
        if (player.PlayerName == PlayerList.Player1 && player.SessionMode == SessionModeList.TestQuests)
        {
            amount = 4;
            wheatAmount = 60;
        }
        else if (player.PlayerName == PlayerList.Player2 && player.SessionMode == SessionModeList.TestQuests)
        {
            amount = 10;
            wheatAmount = 80;
        }
        else if (player.PlayerName == PlayerList.Player1 && player.SessionMode == SessionModeList.SimpleTesting)
        {
            amount = 5;

        }
        else if (player.PlayerName == PlayerList.Player2)
        {
            amount = 8;
        }
        if (wheatAmount < amount)
        {
            wheatAmount = amount;
        }
        var dict = new Dictionary<string, int>
        {
            [CountryItemList.Wheat] = wheatAmount,
            [CountryItemList.Corn] = amount,
            [CountryItemList.Shrimp] = amount,
            [CountryItemList.Honey] = amount
        };
        return Task.FromResult(dict);
    }
}