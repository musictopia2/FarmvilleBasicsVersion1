namespace Phase06Autoresume.DataAccess.Crops;
public class CropInstanceDocument
{
    required public BasicList<CropAutoResumeModel> Slots { get; set; } = [];

    required public PlayerState Player { get; set; }
}