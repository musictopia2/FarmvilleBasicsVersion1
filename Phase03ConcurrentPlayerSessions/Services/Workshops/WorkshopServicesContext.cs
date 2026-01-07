namespace Phase03ConcurrentPlayerSessions.Services.Workshops;
public class WorkshopServicesContext
{
    required
    public IWorkshopRegistry WorkshopRegistry { get; init; }
    required
    public IWorkshopInstances WorkshopInstances { get; init; }
    required
    public IWorkshopPolicy WorkshopPolicy { get; init; }
}