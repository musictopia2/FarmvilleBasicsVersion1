namespace Phase17BeginningDataAbstractionsPart1.Services.Crops;
public interface ICropRegistry
{
    Task<BasicList<CropModel>> GetCropsAsync();

}