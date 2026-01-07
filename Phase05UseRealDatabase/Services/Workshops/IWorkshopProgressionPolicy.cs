namespace Phase05UseRealDatabase.Services.Workshops;
public interface IWorkshopProgressionPolicy
{
    Task<bool> CanUnlockAsync(BasicList<WorkshopState> workshops, string buildingName);
    Task<WorkshopState> UnlockAsync(BasicList<WorkshopState> workshops, string buildingName);
    Task<bool> CanLockAsync(BasicList<WorkshopState> workshops, string buildingName);
    Task<WorkshopState> LockAsync(BasicList<WorkshopState> workshops, string buildingName);
}