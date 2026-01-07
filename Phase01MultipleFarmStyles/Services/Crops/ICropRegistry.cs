namespace Phase01MultipleFarmStyles.Services.Crops;
public interface ICropRegistry
{
    Task<BasicList<CropRecipe>> GetCropsAsync();

}