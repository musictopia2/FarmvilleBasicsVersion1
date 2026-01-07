namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Workshops;
public interface IWorkshopInstances
{
    Task<BasicList<WorkshopDataModel>> GetWorkshopInstancesAsync();
}