namespace Phase17BeginningDataAbstractionsPart1.Services.Trees;
public interface ITreeRecipes
{
    Task<BasicList<TreeRecipe>> GetTreesAsync();
}