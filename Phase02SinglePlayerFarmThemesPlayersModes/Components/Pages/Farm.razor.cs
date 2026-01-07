namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Pages;
public partial class Farm(IGameTimer timer, PlayerState player)
{
    [Parameter]
    public string FarmTheme { get; set; } = string.Empty;

    [Parameter]
    public string Player { get; set; } = string.Empty;

    [Parameter]
    public string SessionMode { get; set; } = string.Empty;

    private bool _loaded = false;
    protected override async Task OnInitializedAsync()
    {
        player.FarmTheme = FarmTheme;
        player.PlayerName = Player;
        player.SessionMode = SessionMode;
        await timer.SetStyleContextAsync();
        _loaded = true;
    }

}