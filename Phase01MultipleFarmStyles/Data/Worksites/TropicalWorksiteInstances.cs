namespace Phase01MultipleFarmStyles.Data.Worksites;
public class TropicalWorksiteInstances : IWorksiteInstances
{
    Task<BasicList<WorksiteDataModel>> IWorksiteInstances.GetWorksiteInstancesAsync()
    {
        BasicList<WorksiteDataModel> output =
            [
                new()
                {
                     Name = TropicalWorksiteListClass.CorelReef,
                     Unlocked = true
                },
                new()
                {
                    Name = TropicalWorksiteListClass.HotSprings,
                    Unlocked = true
                }
            ];
        return Task.FromResult(output);
    }
}