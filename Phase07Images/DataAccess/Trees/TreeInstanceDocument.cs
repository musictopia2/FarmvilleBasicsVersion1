namespace Phase07Images.DataAccess.Trees;
public class TreeInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<TreeAutoResumeModel> Trees { get; set; }
}