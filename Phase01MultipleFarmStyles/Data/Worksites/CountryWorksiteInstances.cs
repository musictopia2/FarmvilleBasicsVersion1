namespace Phase01MultipleFarmStyles.Data.Worksites;
public class CountryWorksiteInstances : IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> IWorksiteInstances.GetWorksiteInstancesAsync()
    {
        BasicList<WorksiteDataModel> output =
            [
                new()
                {
                     Name = CountryWorksiteListClass.GrandmasGlade,
                     Unlocked = false
                },
                new()
                {
                    Name = CountryWorksiteListClass.Pond,
                    Unlocked = false
                }
            ];
        return Task.FromResult(output);
    }
}