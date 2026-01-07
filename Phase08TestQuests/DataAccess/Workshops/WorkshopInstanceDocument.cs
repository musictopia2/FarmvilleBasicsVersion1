namespace Phase08TestQuests.DataAccess.Workshops;
public class WorkshopInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorkshopAutoResumeModel> Workshops { get; set; }
}