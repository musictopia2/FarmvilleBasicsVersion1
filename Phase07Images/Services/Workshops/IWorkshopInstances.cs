namespace Phase07Images.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopAutoResumeModel>> GetWorkshopInstancesAsync();
}