namespace Phase05UseRealDatabase.Services.Worksites;
public interface IWorksiteFactory
{
    WorksiteServicesContext GetWorksiteServices(PlayerState player);
}