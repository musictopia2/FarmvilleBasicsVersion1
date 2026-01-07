namespace Phase02AutoresumeDatabase.ImportClasses;
public static class ImportStartClass
{
    public static async Task ImportStartAsync()
    {
        BasicList<PlayerState> output = [];

        string[] players = { PlayerList.Player1, PlayerList.Player2 };
        string[] themes = { FarmThemeList.Country, FarmThemeList.Tropical };
        string[] modes = { SessionModeList.SimpleTesting, SessionModeList.SampleProduction };

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
