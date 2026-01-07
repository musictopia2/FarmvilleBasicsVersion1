namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Workshops;
public interface IWorkshopRegistry
{
    Task<BasicList<WorkshopRecipe>> GetWorkshopRecipesAsync();
}