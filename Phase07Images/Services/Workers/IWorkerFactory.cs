namespace Phase07Images.Services.Workers;
public interface IWorkerFactory
{
    WorkerServicesContext GetWorkerServices(PlayerState player);
}