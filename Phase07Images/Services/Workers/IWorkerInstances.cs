namespace Phase07Images.Services.Workers;
public interface IWorkerInstances
{
    Task<BasicList<WorkerDataModel>> GetWorkerInstancesAsync();
}