namespace Phase06Autoresume.Services.Worksites;
public interface IWorksiteFactory
{
    WorksiteServicesContext GetWorksiteServices(PlayerState player);
}