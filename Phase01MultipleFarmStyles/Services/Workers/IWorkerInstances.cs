namespace Phase01MultipleFarmStyles.Services.Workers;
public interface IWorkerInstances
{
    Task<BasicList<WorkerDataModel>> GetWorkerInstancesAsync();
}