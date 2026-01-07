namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Trees;
public interface ITreeRecipes
{
    Task<BasicList<TreeRecipe>> GetTreesAsync();
}