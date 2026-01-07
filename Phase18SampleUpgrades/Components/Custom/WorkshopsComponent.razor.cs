namespace Phase18SampleUpgrades.Components.Custom;
public partial class WorkshopsComponent(WorkshopManager manager) : IDisposable
{
    private BasicList<WorkshopView> _workshops = [];
    override protected void OnInitialized()
    {
        manager.OnWorkshopsUpdated += Refresh;
        UpdateWorkshops();
    }
    private void UpdateWorkshops()
    {
        _workshops = manager.GetUnlockedWorkshops;
    }
    private void Refresh()
    {
        UpdateWorkshops();
        StateHasChanged();
    }

    private void SelectWorkshop(WorkshopView workshop)
    {
        if (WorkshopSelected.HasDelegate)
        {
            WorkshopSelected.InvokeAsync(workshop);
        }
    }

    public void Dispose()
    {
        manager?.OnWorkshopsUpdated -= Refresh;
        GC.SuppressFinalize(this);
    }

    [Parameter]
    public EventCallback<WorkshopView> WorkshopSelected { get; set; }
}