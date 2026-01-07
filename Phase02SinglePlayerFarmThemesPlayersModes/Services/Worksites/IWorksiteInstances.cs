namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> GetWorksiteInstancesAsync();
}