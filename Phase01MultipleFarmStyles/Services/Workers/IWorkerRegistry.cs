namespace Phase01MultipleFarmStyles.Services.Workers;
public interface IWorkerRegistry
{
    Task<BasicList<WorkerRecipe>> GetWorkersAsync();
}