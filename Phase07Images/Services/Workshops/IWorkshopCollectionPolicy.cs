namespace Phase07Images.Services.Workshops;
public interface IWorkshopCollectionPolicy
{
    Task<bool> IsAutomaticAsync();
}