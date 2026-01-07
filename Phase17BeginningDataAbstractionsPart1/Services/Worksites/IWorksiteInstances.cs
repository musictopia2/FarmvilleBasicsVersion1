namespace Phase17BeginningDataAbstractionsPart1.Services.Worksites;
public interface IWorksiteInstances
{
    Task<BasicList<string>> GetWorksiteInstances();
}