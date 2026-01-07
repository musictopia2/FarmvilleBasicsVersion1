namespace Phase04CollectionProcesses.Data.General;
public class StartFarmRegistry : IStartFarmRegistry
{
    Task<BasicList<PlayerState>> IStartFarmRegistry.GetFarmsAsync()
    {
        BasicList<PlayerState> output = [];
        foreach (var player in new[] { PlayerList.Player1, PlayerList.Player2 })
        {
            foreach (var theme in new[] { FarmThemeList.Tropical, FarmThemeList.Country })
            {
                foreach (var mode in new[] { SessionModeList.SimpleTesting, SessionModeList.SimpleProduction, SessionModeList.TestQuests })
                {
                    output.Add(new PlayerState()
                    {
                        FarmTheme = theme,
                        SessionMode = mode,
                        PlayerName = player
                    });
                }
            }
        }
        return Task.FromResult(output);
    }
}