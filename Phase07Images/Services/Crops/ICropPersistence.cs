namespace Phase07Images.Services.Crops;
public interface ICropPersistence
{
    Task SaveCropsAsync(BasicList<CropAutoResumeModel> slots);
}