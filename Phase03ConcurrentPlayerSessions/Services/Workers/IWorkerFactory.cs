namespace Phase03ConcurrentPlayerSessions.Services.Workers;
public interface IWorkerFactory
{
    WorkerServicesContext GetWorkerServices(PlayerState player);
}