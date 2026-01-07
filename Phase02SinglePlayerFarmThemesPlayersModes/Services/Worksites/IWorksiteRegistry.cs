namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Worksites;
public interface IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> GetWorksitesAsync();
}