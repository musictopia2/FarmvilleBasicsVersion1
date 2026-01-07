namespace Phase05UseRealDatabase.DataAccess.Workers;
public class WorkerFactory : IWorkerFactory
{
    WorkerServicesContext IWorkerFactory.GetWorkerServices(PlayerState player)
    {
        
        IWorkerRegistry register;
        register = new WorkerRecipeDatabase(player);
        WorkerServicesContext output = new()
        {
            WorkerPolicy = new BasicWorkerPolicy(),
            WorkerRegistry = register,
            WorkerInstances = new BasicWorkerInstances(register)
        };
        return output;
    }
}