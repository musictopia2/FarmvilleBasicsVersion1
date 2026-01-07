namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.General;
public class PlayerState
{
    public string PlayerName { get; set; } = "";
    public string FarmTheme { get; set; } = "";
    public string SessionMode { get; set; } = ""; //this is useful if i wanted special modes for different games.
}