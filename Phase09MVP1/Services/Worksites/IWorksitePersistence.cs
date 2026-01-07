namespace Phase09MVP1.Services.Worksites;
public interface IWorksitePersistence
{
    Task SaveWorksitesAsync(BasicList<WorksiteAutoResumeModel> worksites);
}