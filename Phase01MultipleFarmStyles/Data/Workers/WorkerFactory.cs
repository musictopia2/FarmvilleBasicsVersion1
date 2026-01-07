namespace Phase01MultipleFarmStyles.Data.Workers;
public class WorkerFactory : IWorkerFactory
{
    WorkerServicesContext IWorkerFactory.GetWorkerServices(string style)
    {
        if (style == FarmStyleList.Country)
        {
            return FromCountry();
        }
        if (style == FarmStyleList.Tropical)
        {
            return FromTropical();
        }
        throw new CustomBasicException("Not Supported");
    }
    private static WorkerServicesContext FromCountry()
    {
        IWorkerRegistry register = new CountryWorkersRegistry();
        return new()
        {
            WorkerRegistry = register,
            WorkerInstances = new CountryWorkerInstances(register),
            WorkerPolicy = new CountryWorkerPolicy(),
        };
    }
    private static WorkerServicesContext FromTropical()
    {
        IWorkerRegistry register = new TropicalWorkersRegistry();
        return new()
        {
            WorkerRegistry = register,
            WorkerInstances = new TropicalWorkerInstances(register),
            WorkerPolicy = new TropicalWorkerPolicy(),
        };
    }
}