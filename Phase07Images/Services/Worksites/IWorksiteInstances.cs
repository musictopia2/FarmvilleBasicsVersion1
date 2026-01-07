namespace Phase07Images.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteAutoResumeModel>> GetWorksiteInstancesAsync();
}