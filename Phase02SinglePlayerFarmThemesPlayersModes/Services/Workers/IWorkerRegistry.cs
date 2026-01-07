namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Workers;
public interface IWorkerRegistry
{
    Task<BasicList<WorkerRecipe>> GetWorkersAsync();
}