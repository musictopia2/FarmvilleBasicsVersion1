namespace Phase07Images.Services.Worksites;
public interface IWorksitePersistence
{
    Task SaveWorksitesAsync(BasicList<WorksiteAutoResumeModel> worksites);
}