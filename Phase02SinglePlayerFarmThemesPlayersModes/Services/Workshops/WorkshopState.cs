namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Workshops;
public class WorkshopState : WorkshopView
{
    public bool Unlocked { get; set; } = true;
    public bool RemainingCraftingJobs { get; set; } //cannot lock a building if in use.
}