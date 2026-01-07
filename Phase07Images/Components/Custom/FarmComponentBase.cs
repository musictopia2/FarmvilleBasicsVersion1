namespace Phase07Images.Components.Custom;
public abstract class FarmComponentBase : ComponentBase
{
    [CascadingParameter]
    private MainFarmContainer? Farm { get; set; }
    protected CropManager CropManager => Farm!.CropManager;
    protected TreeManager TreeManager => Farm!.TreeManager;
    protected WorkshopManager WorkshopManager => Farm!.WorkshopManager;
    protected AnimalManager AnimalManager => Farm!.AnimalManager;
    protected WorksiteManager WorksiteManager => Farm!.WorksiteManager;
    protected Inventory Inventory => Farm!.Inventory;
}