namespace Phase17BeginningDataAbstractionsPart1.Data.Workshops;
public class WorkshopInstances(IWorkshopRegistry recipes) : IWorkshopInstances
{
    async Task<BasicList<WorkshopModel>> IWorkshopInstances.GetWorkshopInstancesAsync()
    {
        var list = await recipes.GetWorkshopRecipesAsync();
        var nexts = list.GroupBy(x => x.BuildingName);
        BasicList<WorkshopModel> output = [];
        foreach (var item in nexts)
        {
            output.Add(new WorkshopModel()
            {
                 Name = item.Key,
                 Capcity = 3 //pretend like i have 3 and not 2.
            });
        }
        return output;
    }
}