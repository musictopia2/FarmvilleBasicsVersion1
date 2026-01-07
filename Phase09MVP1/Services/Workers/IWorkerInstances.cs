namespace Phase09MVP1.Services.Workers;
public interface IWorkerInstances
{
    Task<BasicList<WorkerDataModel>> GetWorkerInstancesAsync();
}