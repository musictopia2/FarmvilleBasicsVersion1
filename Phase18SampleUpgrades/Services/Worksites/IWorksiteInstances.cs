namespace Phase18SampleUpgrades.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> GetWorksiteInstancesAsync();
}