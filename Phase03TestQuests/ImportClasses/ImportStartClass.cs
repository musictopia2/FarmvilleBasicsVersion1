namespace Phase03TestQuests.ImportClasses;
public static class ImportStartClass
{
    public static async Task ImportStartAsync()
    {
        BasicList<PlayerState> output = [];

        //string[] players = { PlayerList.Andy, PlayerList.Cristina };
        string[] themes = { FarmThemeList.Country, FarmThemeList.Tropical };
        //string[] modes = { SessionModeList.SimpleTesting, SessionModeList.SampleProduction };


        string[] players = { PlayerList.Player1 };
        string[] modes = { SessionModeList.SimpleTesting };

        foreach (var player in players)
        {
            foreach (var theme in themes)
            {
                foreach (var mode in modes)
                {
                    output.Add(new PlayerState()
                    {
                        PlayerName = player,
                        FarmTheme = theme,
                        SessionMode = mode
                    });
                }
            }
        }


        StartFarmDatabase db = new();
        await db.ImportAsync(output);

    }
}
