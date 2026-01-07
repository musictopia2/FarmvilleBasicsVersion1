namespace Phase09MVP1.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteAutoResumeModel>> GetWorksiteInstancesAsync();
}