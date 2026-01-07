namespace Phase01MultipleFarmStyles.Services.Workshops;
public class WorkshopState : WorkshopView
{
    public bool Unlocked { get; set; } = true;
    public bool RemainingCraftingJobs { get; set; } //cannot lock a building if in use.
}