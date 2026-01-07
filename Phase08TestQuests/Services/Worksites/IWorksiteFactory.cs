namespace Phase08TestQuests.Services.Worksites;
public interface IWorksiteFactory
{
    WorksiteServicesContext GetWorksiteServices(PlayerState player);
}