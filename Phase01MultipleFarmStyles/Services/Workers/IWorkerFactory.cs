namespace Phase01MultipleFarmStyles.Services.Workers;
public interface IWorkerFactory
{
    WorkerServicesContext GetWorkerServices(string style);
}