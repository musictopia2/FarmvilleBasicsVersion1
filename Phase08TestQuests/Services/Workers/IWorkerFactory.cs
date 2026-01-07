namespace Phase08TestQuests.Services.Workers;
public interface IWorkerFactory
{
    WorkerServicesContext GetWorkerServices(PlayerState player);
}