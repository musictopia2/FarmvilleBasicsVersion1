namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class WorksitesComponent(WorksiteManager manager)
{
    private BasicList<string> _worksites = [];
    override protected void OnInitialized()
    {
        _worksites = manager.GetAllWorksites();
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
}