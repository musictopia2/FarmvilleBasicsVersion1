namespace Phase03ConcurrentPlayerSessions.Components.Custom;
public partial class WorksitesComponent : IDisposable
{
    private BasicList<string> _worksites = [];
    override protected void OnInitialized()
    {
        UpdateWorksites();
        WorksiteManager.OnWorksitesUpdated += Refresh;
    }

    private void UpdateWorksites()
    {
        _worksites = WorksiteManager.GetUnlockedWorksites();
    }
    private void Refresh()
    {
        UpdateWorksites();
        StateHasChanged();
    }

    [Parameter]
    public EventCallback<string> WorksiteSelected { get; set; }
    private void SelectWorsite(string site)
    {
        if (WorksiteSelected.HasDelegate)
        {
            WorksiteSelected.InvokeAsync(site);
        }
    }
    public void Dispose()
    {
        WorksiteManager.OnWorksitesUpdated -= Refresh;
        GC.SuppressFinalize(this);
    }
}