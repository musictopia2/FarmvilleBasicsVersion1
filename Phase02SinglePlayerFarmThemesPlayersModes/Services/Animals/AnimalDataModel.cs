namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Animals;
public class AnimalDataModel
{
    public string Name { get; set; } = "";
    public bool Unlocked { get; set; } = true;
    public int UnlockedOptionCount { get; set; } = 1;
    //eventually needs to know about options you are allowed to do (later)
}