namespace Phase06Autoresume.DataAccess.Workshops;
public class WorkshopInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorkshopAutoResumeModel> Workshops { get; set; }
}