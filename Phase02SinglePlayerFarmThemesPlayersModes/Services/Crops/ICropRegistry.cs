namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Crops;
public interface ICropRegistry
{
    Task<BasicList<CropRecipe>> GetCropsAsync();

}