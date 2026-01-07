namespace Phase06Autoresume.DataAccess.Worksites;
public class WorksiteInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorksiteAutoResumeModel> Worksites { get; set; } = [];
}