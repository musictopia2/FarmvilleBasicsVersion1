namespace Phase05UseRealDatabase.Services.Workshops;
public interface IWorkshopFactory
{
    WorkshopServicesContext GetWorkshopServices(PlayerState player);
}