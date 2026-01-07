namespace Phase13SingleWorksites.Services;
public class WorkerModel
{
    public EnumWorkerType WorkerType { get; set; }
    public EnumWorkerStatus WorkerStatus { get; set; }
    public string WorkerName { get; set; } = ""; //this is the ui.
    public string Details { get; set; } = ""; //you can have details about this worker.
}