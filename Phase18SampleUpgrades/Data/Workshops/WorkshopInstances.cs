namespace Phase18SampleUpgrades.Data.Workshops;
public class WorkshopInstances(IWorkshopRegistry recipes) : IWorkshopInstances
{
    async Task<BasicList<WorkshopDataModel>> IWorkshopInstances.GetWorkshopInstancesAsync()
    {
        var list = await recipes.GetWorkshopRecipesAsync();
        var nexts = list.GroupBy(x => x.BuildingName);
        BasicList<WorkshopDataModel> output = [];
        foreach (var item in nexts)
        {
            3.Times(x =>
            {
                bool unlocked;
                if (x > 1)
                {
                    unlocked = false;
                }
                else if (item.Key == WorkshopList.PastryOven)
                {
                    unlocked = false;
                }
                else
                {
                    unlocked = true;
                }
                output.Add(new WorkshopDataModel()
                    {
                        Name = item.Key,
                        Unlocked = unlocked,
                        Capcity = 3 //pretend like i have 3 and not 2.
                    });
            });            
        }
        return output;
    }
}