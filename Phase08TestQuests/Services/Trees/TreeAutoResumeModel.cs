namespace Phase08TestQuests.Services.Trees;
public class TreeAutoResumeModel
{
    public string TreeName { get; set; } = "";
    public bool Unlocked { get; set; } = true;
    public int TreesReady { get; set; }
    public EnumTreeState State { get; set; } = EnumTreeState.Collecting;
    public DateTime? StartedAt { get; set; }
    public DateTime? TempStart { get; set; }
    // Production timing is determined by the associated TreeRecipe.
}