namespace Phase17BeginningDataAbstractionsPart1.Data.Workers;
public class WorkersRegistry : IWorkerRegistry
{
    async Task<BasicList<WorkerModel>> IWorkerRegistry.GetWorkersAsync()
    {
        BasicList<WorkerModel> output = [];
        WorkerModel worker = new()
        {
            WorkerName = WorkerListClass.Bob,
            Details = "Has high chances of getting chives at grandmas glade and receives one carrot from the pond.   Finally has medium chance of receiving farmers soup in grandmas glade"
        };
        WorkerBenefit benefit = new()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.Chive,
            ChanceModifier = 0.3
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = WorksiteListClass.Pond,
            Item = ItemList.Carrot,
            Guarantee = true
            //QuantityBonus = 1 //i think is needed
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.FarmersSoup,
            ChanceModifier = 0.6
            //QuantityBonus = 1 //i think is needed
        };
        worker.Benefits.Add(benefit);
        //try without the bonus (if nothing is given and is not a normal benefit, then needs to be 1).
        output.Add(worker);
        worker = new()
        {
            WorkerName = WorkerListClass.Alice,
            Details = "General Worker."
        };
        output.Add(worker);
        worker = new()
        {
            WorkerName = WorkerListClass.Clara,
            Details = "Expert in picking strawberries. Guarantees one strawberry per job in grandmas glade."
        };
        benefit = new()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.Strawberry,
            Guarantee = true //must show this or no chances.
            //QuantityBonus = 1 //otherwise no strawberries.
        };
        output.Add(worker);
        worker.Benefits.Add(benefit);
        worker = new()
        {
            WorkerName = WorkerListClass.Daniel,
            Details = "Specializes in finding Granilla Bars in gradmas glade. Has a small chance to harvest them."
        };
        benefit = new()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.GranolaBar,
            ChanceModifier = 0.75 //was 0.15 but had to increase the chances so if i had a quest for it, has to think about how to do it.
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);


        // Worker 5: Extra Trout from Pond
        worker = new()
        {
            WorkerName = WorkerListClass.Ethan,
            Details = "Expert fisherman. Guarantees one extra trout from the pond and gives one extra blackberry from grandmas glade."
        };
        benefit = new()
        {
            Worksite = WorksiteListClass.Pond,
            Item = ItemList.Trout,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.Blackberry,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);

        // Worker 6: Extra Bass from Pond (no chance modifier)
        worker = new WorkerModel()
        {
            WorkerName = WorkerListClass.Fiona,
            Details = "Specializes in catching bass at the pond. Gives one bass but does not increase the chances of finding one."
        };
        benefit = new WorkerBenefit()
        {
            Worksite = WorksiteListClass.Pond,
            Item = ItemList.Bass,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);

        // Worker 7: Extra Mint chance from Pond
        worker = new()
        {
            WorkerName = WorkerListClass.George,
            Details = "Herbal expert. Increases mint chance at the pond and gives extra blackberries at Grandma’s Glade."
        };
        benefit = new WorkerBenefit()
        {
            Worksite = WorksiteListClass.Pond,
            Item = ItemList.Mint,
            ChanceModifier = 0.25    // +25% chance
        };
        worker.Benefits.Add(benefit);
        benefit = new WorkerBenefit()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.Blackberry,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);
        return output;
    }
}