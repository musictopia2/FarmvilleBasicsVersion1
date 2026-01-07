namespace Phase17BeginningDataAbstractionsPart1.Services.Workers;
public interface IWorkerRegistry
{
    Task<BasicList<WorkerModel>> GetWorkersAsync();
}