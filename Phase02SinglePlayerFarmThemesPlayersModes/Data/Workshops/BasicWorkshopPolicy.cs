namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Workshops;
public class BasicWorkshopPolicy : IWorkshopPolicy
{
    Task<bool> IWorkshopPolicy.CanLockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        return Task.FromResult(false);
    }

    Task<bool> IWorkshopPolicy.CanUnlockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        return Task.FromResult(false);
    }

    Task<WorkshopState> IWorkshopPolicy.LockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        throw new NotImplementedException();
    }

    Task<WorkshopState> IWorkshopPolicy.UnlockAsync(BasicList<WorkshopState> workshops, string buildingName)
    {
        throw new NotImplementedException();
    }
}
