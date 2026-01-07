namespace Phase01MultipleFarmStyles.Services.Worksites;
public interface IWorksiteRegistry
{
    Task<BasicList<WorksiteRecipe>> GetWorksitesAsync();
}