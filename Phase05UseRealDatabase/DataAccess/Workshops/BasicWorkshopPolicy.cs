namespace Phase05UseRealDatabase.DataAccess.Workshops;
public class BasicWorkshopPolicy : IWorkshopProgressionPolicy
{
    Task<bool> IWorkshopProgressionPolicy.CanLockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        return Task.FromResult(false);
    }

    Task<bool> IWorkshopProgressionPolicy.CanUnlockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        return Task.FromResult(false);
    }

    Task<WorkshopState> IWorkshopProgressionPolicy.LockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        throw new NotImplementedException();
    }

    Task<WorkshopState> IWorkshopProgressionPolicy.UnlockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        throw new NotImplementedException();
    }
}
