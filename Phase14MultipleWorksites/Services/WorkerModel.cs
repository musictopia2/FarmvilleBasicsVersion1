namespace Phase14MultipleWorksites.Services;
public class WorkerModel
{
    public EnumWorkerStatus WorkerStatus { get; set; }
    public EnumWorksiteLocation CurrentLocation { get; set; } //helpful so it can show proper ui information.
    public EnumWorksiteLocation LockedLocation { get; init; } //i think if locked, must be set to begin with.
    public string WorkerName { get; set; } = ""; //this is the ui.
    public BasicList<WorkerBenefit> Benefits { get; set; } = [];
    public string Details { get; set; } = ""; //you can have details about this worker.
}