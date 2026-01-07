namespace Phase06Autoresume.Services.General;
public record class PlayerState
{
    public string PlayerName { get; init; } = "";
    public string FarmTheme { get; init; } = "";
    public string SessionMode { get; init; } = ""; //this is useful if i wanted special modes for different games.
}