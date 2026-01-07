namespace Phase07Images.Services.Workers;
public class WorkerState
{
    public string Name { get; set; } = "";
    public bool Unlocked { get; set; }
    public EnumWorkerStatus Status { get; set; }
}