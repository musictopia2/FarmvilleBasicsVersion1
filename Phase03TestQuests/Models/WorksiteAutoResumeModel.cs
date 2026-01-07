namespace Phase03TestQuests.Models;
public class WorksiteAutoResumeModel
{
    public string Name { get; set; } = "";
    public bool Unlocked { get; set; } = true;
    public DateTime? StartedAt { get; set; }
    public EnumWorksiteState Status { get; set; } = EnumWorksiteState.None;
    public BasicList<WorkerRecipe> Workers { get; set; } = []; //this should not require dto.
    public BasicList<ItemAmount> Rewards { get; set; } = [];
}