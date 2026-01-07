namespace Phase04CollectionProcesses.Components.Custom;
public partial class WorkshopsComponent : IDisposable
{
    private BasicList<WorkshopView> _workshops = [];
    override protected void OnInitialized()
    {
        WorkshopManager.OnWorkshopsUpdated += Refresh;
        UpdateWorkshops();
    }
    private void UpdateWorkshops()
    {
        _workshops = WorkshopManager.GetUnlockedWorkshops;
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
        WorkshopManager?.OnWorkshopsUpdated -= Refresh;
        GC.SuppressFinalize(this);
    }

    [Parameter]
    public EventCallback<WorkshopView> WorkshopSelected { get; set; }
}