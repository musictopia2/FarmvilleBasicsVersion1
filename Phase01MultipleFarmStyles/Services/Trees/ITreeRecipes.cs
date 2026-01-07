namespace Phase01MultipleFarmStyles.Services.Trees;
public interface ITreeRecipes
{
    Task<BasicList<TreeRecipe>> GetTreesAsync();
}