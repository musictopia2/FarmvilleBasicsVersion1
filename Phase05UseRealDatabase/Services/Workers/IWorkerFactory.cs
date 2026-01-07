namespace Phase05UseRealDatabase.Services.Workers;
public interface IWorkerFactory
{
    WorkerServicesContext GetWorkerServices(PlayerState player);
}