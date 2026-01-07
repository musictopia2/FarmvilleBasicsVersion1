namespace Phase05UseRealDatabase.Services.Worksites;
public interface IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> GetWorksitesAsync();
}