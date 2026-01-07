using Microsoft.Win32;

namespace Phase08TestQuests.Components.Pages;
public partial class Farm(GameRegistry registry)
{
    [Parameter]
    public string FarmTheme { get; set; } = string.Empty;

    [Parameter]
    public string Player { get; set; } = string.Empty;

    [Parameter]
    public string SessionMode { get; set; } = string.Empty;
    private MainFarmContainer? _farmContainer;
    protected override void OnInitialized()
    {
        PlayerState player = new()
        {
            FarmTheme = FarmTheme,
            PlayerName = Player,
            SessionMode = SessionMode
        };
        _farmContainer = registry.GetFarm(player);
        base.OnInitialized();
    }


}