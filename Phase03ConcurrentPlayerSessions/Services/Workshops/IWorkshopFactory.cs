namespace Phase03ConcurrentPlayerSessions.Services.Workshops;
public interface IWorkshopFactory
{
    WorkshopServicesContext GetWorkshopServices(PlayerState player);
}