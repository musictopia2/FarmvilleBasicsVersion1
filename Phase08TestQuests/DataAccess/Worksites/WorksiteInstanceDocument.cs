namespace Phase08TestQuests.DataAccess.Worksites;
public class WorksiteInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorksiteAutoResumeModel> Worksites { get; set; } = [];
}