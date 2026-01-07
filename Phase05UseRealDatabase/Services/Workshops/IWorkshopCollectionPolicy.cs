namespace Phase05UseRealDatabase.Services.Workshops;
public interface IWorkshopCollectionPolicy
{
    Task<bool> IsAutomaticAsync();
}