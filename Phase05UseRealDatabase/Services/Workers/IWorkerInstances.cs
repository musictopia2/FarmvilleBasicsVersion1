namespace Phase05UseRealDatabase.Services.Workers;
public interface IWorkerInstances
{
    Task<BasicList<WorkerDataModel>> GetWorkerInstancesAsync();
}