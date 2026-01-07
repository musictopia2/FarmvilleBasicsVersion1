namespace Phase01MultipleFarmStyles.Services.Workshops;
public interface IWorkshopFactory
{
    WorkshopServicesContext GetWorkshopServices(string style);
}