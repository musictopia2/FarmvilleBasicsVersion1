namespace Phase07Images.DataAccess.Animals;
public class AnimalInstanceDocument
{
    required public BasicList<AnimalAutoResumeModel> Animals { get; set; }
    required public PlayerState Player { get; set; }
}