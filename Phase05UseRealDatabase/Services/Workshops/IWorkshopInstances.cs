namespace Phase05UseRealDatabase.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopDataModel>> GetWorkshopInstancesAsync();
}