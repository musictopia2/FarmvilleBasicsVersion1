namespace Phase06Autoresume.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteAutoResumeModel>> GetWorksiteInstancesAsync();
}