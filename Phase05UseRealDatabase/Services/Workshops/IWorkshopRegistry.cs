namespace Phase05UseRealDatabase.Services.Workshops;
public interface IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> GetWorkshopRecipesAsync();
}