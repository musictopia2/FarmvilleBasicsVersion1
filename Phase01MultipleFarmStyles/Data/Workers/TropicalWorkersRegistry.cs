namespace Phase01MultipleFarmStyles.Data.Workers;
public class TropicalWorkersRegistry : IWorkerRegistry
{
    async Task<BasicList<WorkerRecipe>> IWorkerRegistry.GetWorkersAsync()
    {
        BasicList<WorkerRecipe> output = [];
        WorkerRecipe worker;

        worker = new()
        {
            WorkerName = TropicalWorkerListClass.Toby,
            Details = "General Worker"
        };
        output.Add(worker);
        worker = new()
        {
            WorkerName = TropicalWorkerListClass.Bob,
            Details = $"Has medium chance of receiving {TropicalItemList.Ceviche}"
        };
        WorkerBenefit benefit = new()
        {
            Worksite = TropicalWorksiteListClass.CorelReef,
            Item = TropicalItemList.Ceviche,
            ChanceModifier = 0.6
            //QuantityBonus = 1 //i think is needed
        };
        worker.Benefits.Add(benefit);
        
        //try without the bonus (if nothing is given and is not a normal benefit, then needs to be 1).
        output.Add(worker);
        worker = new()
        {
            WorkerName = TropicalWorkerListClass.Alice,
            Details = "General Worker."
        };
        output.Add(worker);
        worker = new()
        {
            WorkerName = TropicalWorkerListClass.Clara,
            Details = "General Worker"
        };
        //they are mostly general workers for now for tropic escape.
        output.Add(worker);
        return output;
    }
}