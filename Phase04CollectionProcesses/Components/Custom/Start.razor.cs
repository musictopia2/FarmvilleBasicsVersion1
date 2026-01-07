namespace Phase04CollectionProcesses.Components.Custom;
public partial class Start(NavigationManager nav)
{
    private void NavigateTo(string farmTheme, string person, string mode)
    {
        nav.NavigateTo($"/farm/{farmTheme}/{person}/{mode}");
    }
}