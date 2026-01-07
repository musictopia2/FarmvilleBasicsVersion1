namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Workers;
public class WorkerFactory(PlayerState player) : IWorkerFactory
{
    WorkerServicesContext IWorkerFactory.GetWorkerServices()
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return FromCountry();
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return FromTropical();
        }
        throw new CustomBasicException("Not Supported");
    }
    private WorkerServicesContext FromCountry()
    {
        IWorkerRegistry register = new CountryWorkersRegistry(player);
        return new()
        {
            WorkerRegistry = register,
            WorkerInstances = new BasicWorkerInstances(register),
            WorkerPolicy = new BasicWorkerPolicy(),
        };
    }
    private WorkerServicesContext FromTropical()
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