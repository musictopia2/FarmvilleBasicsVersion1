namespace Phase02AutoresumeDatabase.Models;
public class WorksiteInstanceDocument
{
    required public PlayerState Player { get; set; }
    required public BasicList<WorksiteAutoResumeModel> Worksites { get; set; } = [];
}