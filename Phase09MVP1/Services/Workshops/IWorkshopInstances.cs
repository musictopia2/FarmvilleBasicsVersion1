namespace Phase09MVP1.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopAutoResumeModel>> GetWorkshopInstancesAsync();
}