namespace Phase04CollectionProcesses.Services.Workshops;
public class WorkshopDataModel
{
    public string Name { get; set; } = "";
    public bool Unlocked { get; set; } = true; //defaults to being unlocked.  can later decide to unlock it later in the game.
    public int Capcity { get; set; } = 2; //defaults to 2
}