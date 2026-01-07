namespace Phase03ConcurrentPlayerSessions.Services.Worksites;
public interface IWorksiteFactory
{
    WorksiteServicesContext GetWorksiteServices(PlayerState player);
}