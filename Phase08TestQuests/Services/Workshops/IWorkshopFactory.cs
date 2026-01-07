namespace Phase08TestQuests.Services.Workshops;
public interface IWorkshopFactory
{
    WorkshopServicesContext GetWorkshopServices(PlayerState player);
}