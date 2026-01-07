namespace Phase03ConcurrentPlayerSessions.Data.Workshops;
public class BasicWorkshopInstances(IWorkshopRegistry recipes) : IWorkshopInstances
{
    async Task<BasicList<WorkshopDataModel>> IWorkshopInstances.GetWorkshopInstancesAsync()
    {
        var list = await recipes.GetWorkshopRecipesAsync();
        var nexts = list.GroupBy(x => x.BuildingName);
        BasicList<WorkshopDataModel> output = [];
        foreach (var item in nexts)
        {
            1.Times(x =>
            {
                output.Add(new WorkshopDataModel()
                {
                    Name = item.Key,
                    Unlocked = true,
                    Capcity = 5
                });
            });
        }
        return output;
    }
}