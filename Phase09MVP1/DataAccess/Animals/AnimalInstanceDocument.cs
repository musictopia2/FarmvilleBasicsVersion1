namespace Phase09MVP1.DataAccess.Animals;
public class AnimalInstanceDocument
{
    required public BasicList<AnimalAutoResumeModel> Animals { get; set; }
    required public FarmKey Farm { get; set; }
}