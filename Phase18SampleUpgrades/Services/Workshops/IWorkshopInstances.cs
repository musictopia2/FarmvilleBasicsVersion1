namespace Phase18SampleUpgrades.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopDataModel>> GetWorkshopInstancesAsync();
}