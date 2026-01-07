namespace Phase03TestQuests.Models;
public class WorkshopInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorkshopAutoResumeModel> Workshops { get; set; }
}