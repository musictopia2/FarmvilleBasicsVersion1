namespace Phase01MultipleFarmStyles.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopDataModel>> GetWorkshopInstancesAsync();
}