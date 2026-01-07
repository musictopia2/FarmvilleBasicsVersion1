namespace Phase05UseRealDatabase.Services.Workers;
public interface IWorkerRegistry
{
    Task<BasicList<WorkerRecipe>> GetWorkersAsync();
}