namespace Phase05UseRealDatabase.Services.Crops;
public interface ICropRegistry
{
    Task<BasicList<CropRecipe>> GetCropsAsync();

}