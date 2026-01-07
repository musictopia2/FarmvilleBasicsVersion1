namespace Phase17BeginningDataAbstractionsPart1.Data.Worksites;
public class WorksiteInstances : IWorksiteInstances
{
    Task<BasicList<string>> IWorksiteInstances.GetWorksiteInstances()
    {
        BasicList<string> output =
            [
                WorksiteListClass.GrandmasGlade,
                WorksiteListClass.Pond
            ];
        return Task.FromResult(output);
    }
}