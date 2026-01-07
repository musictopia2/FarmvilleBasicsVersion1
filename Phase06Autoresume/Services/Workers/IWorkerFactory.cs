namespace Phase06Autoresume.Services.Workers;
public interface IWorkerFactory
{
    WorkerServicesContext GetWorkerServices(PlayerState player);
}