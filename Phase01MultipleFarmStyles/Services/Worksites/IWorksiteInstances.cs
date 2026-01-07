namespace Phase01MultipleFarmStyles.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> GetWorksiteInstancesAsync();
}