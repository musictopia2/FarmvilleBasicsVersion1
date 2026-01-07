namespace Phase03ConcurrentPlayerSessions.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> GetWorksiteInstancesAsync();
}