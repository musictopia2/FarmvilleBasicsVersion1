namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Workers;
public interface IWorkerInstances
{
    Task<BasicList<WorkerDataModel>> GetWorkerInstancesAsync();
}