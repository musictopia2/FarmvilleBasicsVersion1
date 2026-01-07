namespace Phase05UseRealDatabase.Services.Trees;
public interface ITreeRecipes
{
    Task<BasicList<TreeRecipe>> GetTreesAsync();
}