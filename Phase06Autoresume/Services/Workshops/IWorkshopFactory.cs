namespace Phase06Autoresume.Services.Workshops;
public interface IWorkshopFactory
{
    WorkshopServicesContext GetWorkshopServices(PlayerState player);
}