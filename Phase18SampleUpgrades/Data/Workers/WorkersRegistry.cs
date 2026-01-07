namespace Phase18SampleUpgrades.Data.Workers;
public class WorkersRegistry : IWorkerRegistry
{
    async Task<BasicList<WorkerRecipe>> IWorkerRegistry.GetWorkersAsync()
    {
        BasicList<WorkerRecipe> output = [];
        WorkerRecipe worker;

        worker = new()
        {
            WorkerName = WorkerListClass.Toby,
            Details = "Has high chances of getting chives at grandmas glade"
        };

        WorkerBenefit benefit = new()
        {
            Worksite = WorksiteListClass.GrandmasGlade,
            Item = ItemList.Chives,
            ChanceModifier = 0.3
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);


        worker = new()
        {
            WorkerName = WorkerListClass.Bob,
            Details = "Receives one carrot from the pond.   Also has medium chance of receiving farmers soup in grandmas glade"
        };
        benefit = new()
        {
            Worksite = WorksiteListClass.Pond,
            Item = ItemList.Carrots,
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
            Item = ItemList.Strawberries,
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
            Item = ItemList.GranillaBars,
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
            Item = ItemList.Blackberries,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);

        // Worker 6: Extra Bass from Pond (no chance modifier)
        worker = new WorkerRecipe()
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
            Item = ItemList.Blackberries,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);
        return output;
    }
}