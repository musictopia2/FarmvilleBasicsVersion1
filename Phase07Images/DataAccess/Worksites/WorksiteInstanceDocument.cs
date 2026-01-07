namespace Phase07Images.DataAccess.Worksites;
public class WorksiteInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorksiteAutoResumeModel> Worksites { get; set; } = [];
}