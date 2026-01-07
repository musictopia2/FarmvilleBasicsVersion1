namespace Phase03TestQuests.Models;
public class AnimalInstanceDocument
{
    required public BasicList<AnimalAutoResumeModel> Animals { get; set; }
    required public PlayerState Player { get; set; }
}