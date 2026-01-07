namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class WorkshopsComponent(WorkshopManager manager)
{
    private BasicList<WorkshopSummary> _workshops = [];
    override protected void OnInitialized()
    {
        _workshops = manager.GetAllWorkshops;
    }
    private void SelectWorkshop(WorkshopSummary workshop)
    {
        if (WorkshopSelected.HasDelegate)
        {
            WorkshopSelected.InvokeAsync(workshop);
        }
    }
    [Parameter]
    public EventCallback<WorkshopSummary> WorkshopSelected { get; set; }
}