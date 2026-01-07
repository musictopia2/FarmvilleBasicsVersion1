namespace Phase17BeginningDataAbstractionsPart1.Data.Crops;
public class BasicCropCount : ICropCountClass
{
    Task<int> ICropCountClass.GetCropCountAsync()
    {
        return Task.FromResult(12); //give 12 to prove that works too.
    }
}