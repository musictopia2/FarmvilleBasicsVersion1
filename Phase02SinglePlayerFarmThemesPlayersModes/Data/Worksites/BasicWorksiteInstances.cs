namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Worksites;
public class BasicWorksiteInstances(IWorksiteRegistry registry) : IWorksiteInstances
{
    async Task<BasicList<WorksiteDataModel>> IWorksiteInstances.GetWorksiteInstancesAsync()
    {
        var list = await registry.GetWorksitesAsync();
        BasicList<WorksiteDataModel> output = [];
        foreach (var item in list)
        {
            output.Add(new()
            {
                Name = item.Location,
                Unlocked = true
            });
        }
        return output;
    }
}