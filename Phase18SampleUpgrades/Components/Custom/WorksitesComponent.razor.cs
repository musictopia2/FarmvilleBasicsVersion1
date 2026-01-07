namespace Phase18SampleUpgrades.Components.Custom;
public partial class WorksitesComponent(WorksiteManager manager) : IDisposable
{
    private BasicList<string> _worksites = [];
    override protected void OnInitialized()
    {
        UpdateWorksites();
        manager.OnWorksitesUpdated += Refresh;
    }

    private void UpdateWorksites()
    {
        _worksites = manager.GetUnlockedWorksites();
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
        manager.OnWorksitesUpdated -= Refresh;
        GC.SuppressFinalize(this);
    }
}