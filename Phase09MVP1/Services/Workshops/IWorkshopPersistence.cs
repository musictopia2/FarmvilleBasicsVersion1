namespace Phase09MVP1.Services.Workshops;
public interface IWorkshopPersistence
{
    Task SaveWorkshopsAsync(BasicList<WorkshopAutoResumeModel> workshops);
}