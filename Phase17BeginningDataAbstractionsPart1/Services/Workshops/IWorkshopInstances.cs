namespace Phase17BeginningDataAbstractionsPart1.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopModel>> GetWorkshopInstancesAsync();
}