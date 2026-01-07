namespace Phase03ConcurrentPlayerSessions.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopDataModel>> GetWorkshopInstancesAsync();
}