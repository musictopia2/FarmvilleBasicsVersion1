namespace Phase07Images.Services.Workshops;
public interface IWorkshopPersistence
{
    Task SaveWorkshopsAsync(BasicList<WorkshopAutoResumeModel> workshops);
}