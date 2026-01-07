namespace Phase01MultipleFarmStyles.Services.Workshops;
public interface IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> GetWorkshopRecipesAsync();
}