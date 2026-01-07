namespace Phase18SampleUpgrades.Data.Workers;
public class WorkerInstances(IWorkerRegistry registry) : IWorkerInstances
{
    async Task<BasicList<WorkerDataModel>> IWorkerInstances.GetWorkerInstancesAsync()
    {
        var list = await registry.GetWorkersAsync();
        BasicList<WorkerDataModel> output = [];
        bool unlocked = true;
        foreach (var item in list)
        {
            output.Add(new()
            {
                Name = item.WorkerName,
                Unlocked = unlocked
            });
            unlocked = false;
        }
        return output;
    }
}