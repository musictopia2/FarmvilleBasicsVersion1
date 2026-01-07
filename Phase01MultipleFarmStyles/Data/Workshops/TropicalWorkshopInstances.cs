namespace Phase01MultipleFarmStyles.Data.Workshops;
public class TropicalWorkshopInstances(IWorkshopRegistry recipes) : IWorkshopInstances
{
    async Task<BasicList<WorkshopDataModel>> IWorkshopInstances.GetWorkshopInstancesAsync()
    {
        var list = await recipes.GetWorkshopRecipesAsync();
        var nexts = list.GroupBy(x => x.BuildingName);
        BasicList<WorkshopDataModel> output = [];
        foreach (var item in nexts)
        {
            2.Times(x =>
            {
                bool unlocked;
                if (x > 1)
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
                        Capcity = 4 //for this pretend like i somehow unlocked 4 of them.
                        //Capcity = 3 //pretend like i have 3 and not 2.
                    });
            });            
        }
        return output;
    }
}