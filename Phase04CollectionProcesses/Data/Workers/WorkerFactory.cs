namespace Phase04CollectionProcesses.Data.Workers;
public class WorkerFactory : IWorkerFactory
{
    WorkerServicesContext IWorkerFactory.GetWorkerServices(PlayerState player)
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return FromCountry(player);
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return FromTropical(player);
        }
        throw new CustomBasicException("Not Supported");
    }
    private static WorkerServicesContext FromCountry(PlayerState player)
    {
        IWorkerRegistry register = new CountryWorkersRegistry(player);
        return new()
        {
            WorkerRegistry = register,
            WorkerInstances = new BasicWorkerInstances(register),
            WorkerPolicy = new BasicWorkerPolicy(),
        };
    }
    private static WorkerServicesContext FromTropical(PlayerState player)
    {
        IWorkerRegistry register = new TropicalWorkersRegistry(player);
        return new()
        {
            WorkerRegistry = register,
            WorkerInstances = new BasicWorkerInstances(register),
            WorkerPolicy = new BasicWorkerPolicy(),
        };
    }
}