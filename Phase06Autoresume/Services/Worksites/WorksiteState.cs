namespace Phase06Autoresume.Services.Worksites;
public class WorksiteState
{
    public string Name { get; set; } = "";
    public bool Unlocked { get; set; }
    public EnumWorksiteState State { get; set; }
}
