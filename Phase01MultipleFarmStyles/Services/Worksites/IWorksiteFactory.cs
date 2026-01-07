namespace Phase01MultipleFarmStyles.Services.Worksites;
public interface IWorksiteFactory
{
    WorksiteServicesContext GetWorksiteServices(string style);
}