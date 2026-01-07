namespace Phase09MVP1.DataAccess.Crops;
public class CropInstanceDocument
{
    required public BasicList<CropAutoResumeModel> Slots { get; set; } = [];
    required public FarmKey Farm { get; set; }
}