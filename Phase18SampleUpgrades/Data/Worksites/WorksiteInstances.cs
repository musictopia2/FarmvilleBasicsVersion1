namespace Phase18SampleUpgrades.Data.Worksites;
public class WorksiteInstances : IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> IWorksiteInstances.GetWorksiteInstancesAsync()
    {
        BasicList<WorksiteDataModel> output =
            [
                new()
                {
                     Name = WorksiteListClass.GrandmasGlade,
                     Unlocked = false
                },
                new()
                {
                    Name = WorksiteListClass.Pond,
                    Unlocked = false
                }
            ];
        return Task.FromResult(output);
    }
}