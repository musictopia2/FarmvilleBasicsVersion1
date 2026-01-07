namespace Phase09MVP1.Services.Crops;
public interface ICropPersistence
{
    Task SaveCropsAsync(BasicList<CropAutoResumeModel> slots);
}