namespace Phase03ConcurrentPlayerSessions.Services.Worksites;
public class WorksiteServicesContext
{
    required
    public IWorksiteRegistry WorksiteRegistry { get; init; }
    required
    public IWorksiteInstances WorksiteInstances { get; init; }
    required
    public IWorksitePolicy WorksitePolicy { get; init; }
}