namespace Phase06Autoresume.DataAccess.Trees;
public class TreeInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<TreeAutoResumeModel> Trees { get; set; }
}