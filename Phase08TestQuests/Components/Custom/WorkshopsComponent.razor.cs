namespace Phase08TestQuests.Components.Custom;
public partial class WorkshopsComponent : IDisposable
{
    private BasicList<WorkshopView> _workshops = [];
    override protected void OnInitialized()
    {
        WorkshopManager.OnWorkshopsUpdated += Refresh;
        UpdateWorkshops();
        base.OnInitialized();
    }
    private void UpdateWorkshops()
    {
        _workshops = WorkshopManager.GetUnlockedWorkshops;
        
    }
    
    private void Refresh()
    {
        UpdateWorkshops();
        InvokeAsync(StateHasChanged);
    }
    

    private void SelectWorkshop(WorkshopView workshop)
    {

        if (workshop.ReadyCount > 0)
        {
            //try to collect.  if it fails, then rethink here.
            if (WorkshopManager.CanPickupManually(workshop) == false)
            {
                // TODO: show "Barn full" / discard UI when storage limits are enabled
                return;
            }
            WorkshopManager.PickupManually(workshop);
            return;
        }

        if (WorkshopSelected.HasDelegate)
        {
            WorkshopSelected.InvokeAsync(workshop);
        }
    }
    private static string Image(WorkshopView workshop) => $"/{workshop.Name}.png";

    public void Dispose()
    {
        WorkshopManager?.OnWorkshopsUpdated -= Refresh;
        GC.SuppressFinalize(this);
    }


    [Parameter]
    public EventCallback<WorkshopView> WorkshopSelected { get; set; }
}