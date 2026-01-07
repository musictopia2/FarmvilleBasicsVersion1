namespace Phase05UseRealDatabase.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> GetWorksiteInstancesAsync();
}