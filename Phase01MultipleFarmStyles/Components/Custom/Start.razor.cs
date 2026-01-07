namespace Phase01MultipleFarmStyles.Components.Custom;
public partial class Start(NavigationManager nav)
{
    private void NavigateTo(string url)
    {
        nav.NavigateTo($"/farm/{url}");
    }
}