namespace Phase07Images.Services.Workshops;
public class WorkshopManualCollectionPolicy : IWorkshopCollectionPolicy
{
    Task<bool> IWorkshopCollectionPolicy.IsAutomaticAsync()
    {
        return Task.FromResult(false);
    }
}