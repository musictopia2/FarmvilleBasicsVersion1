namespace Phase04CollectionProcesses.Data.General;
public class TropicalBasicStartingInventoryClass : IStartingInventoryProvider
{
    Task<Dictionary<string, int>> IStartingInventoryProvider.GetStartingInventoryAsync(PlayerState player)
    {
        int amount;
        int pineappleAmount = 8;
        amount = 8;
        if (player.PlayerName == PlayerList.Player1 && player.SessionMode == SessionModeList.TestQuests)
        {
            amount = 20;
            pineappleAmount = 60;
        }
        else if (player.PlayerName == PlayerList.Player2 && player.SessionMode == SessionModeList.TestQuests)
        {
            amount = 30;
            pineappleAmount = 80;
        }
        else if (player.PlayerName == PlayerList.Player1 && player.SessionMode == SessionModeList.SimpleTesting)
        {
            amount = 15;

        }
        else if (player.PlayerName == PlayerList.Player2)
        {
            amount = 10;
        }
        if (pineappleAmount < amount)
        {
            pineappleAmount = amount;
        }
        var dict = new Dictionary<string, int>
        {
            [TropicalItemList.Pineapple] = pineappleAmount,
            [TropicalItemList.Rice] = amount,
            [TropicalItemList.Orchid] = amount,
            [TropicalItemList.SugarCane] = amount
        };
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            dict[TropicalItemList.PineappleSmootie] = 2;
        }
        return Task.FromResult(dict);
    }
}