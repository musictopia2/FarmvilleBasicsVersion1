namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Custom;
public partial class Start(NavigationManager nav)
{
    private void NavigateTo(string farmTheme, string person, string mode)
    {
        nav.NavigateTo($"/farm/{farmTheme}/{person}/{mode}");
    }
}