namespace Phase04CollectionProcesses.Data.Workers;
public class CountryWorkersRegistry(PlayerState player) : IWorkerRegistry
{
    async Task<BasicList<WorkerRecipe>> IWorkerRegistry.GetWorkersAsync()
    {
        BasicList<WorkerRecipe> output = [];
        WorkerRecipe worker;

        worker = new()
        {
            WorkerName = CountryWorkerListClass.Toby,
            Details = "Has high chances of getting chives at grandmas glade"
        };

        WorkerBenefit benefit = new()
        {
            Worksite = CountryWorksiteListClass.GrandmasGlade,
            Item = CountryItemList.Chives,
            ChanceModifier = 0.3
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);
        bool receiveFarmerSoup;
        string details = "";

        double granillaChances = 0;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            receiveFarmerSoup = true;
            granillaChances = 0.75;
            details = "Receives one carrot from the pond.   Also has medium chance of receiving farmers soup in grandmas glade";
        }
        else
        {
            receiveFarmerSoup = false;
            granillaChances = 0.15;
            details = "Receives one carrot from the pond.";
        }
        worker = new()
        {
            WorkerName = CountryWorkerListClass.Bob,
            Details = details
        };
        benefit = new()
        {
            Worksite = CountryWorksiteListClass.Pond,
            Item = CountryItemList.Carrots,
            Guarantee = true
            //QuantityBonus = 1 //i think is needed
        };
        worker.Benefits.Add(benefit);
        if (receiveFarmerSoup)
        {
            benefit = new()
            {
                Worksite = CountryWorksiteListClass.GrandmasGlade,
                Item = CountryItemList.FarmersSoup,
                ChanceModifier = 0.6
                //QuantityBonus = 1 //i think is needed
            };
            worker.Benefits.Add(benefit);
        }

        //try without the bonus (if nothing is given and is not a normal benefit, then needs to be 1).
        output.Add(worker);
        worker = new()
        {
            WorkerName = CountryWorkerListClass.Alice,
            Details = "General Worker."
        };
        output.Add(worker);
        worker = new()
        {
            WorkerName = CountryWorkerListClass.Clara,
            Details = "Expert in picking strawberries. Guarantees one strawberry per job in grandmas glade."
        };
        benefit = new()
        {
            Worksite = CountryWorksiteListClass.GrandmasGlade,
            Item = CountryItemList.Strawberries,
            Guarantee = true //must show this or no chances.
            //QuantityBonus = 1 //otherwise no strawberries.
        };
        output.Add(worker);
        worker.Benefits.Add(benefit);
        worker = new()
        {
            WorkerName = CountryWorkerListClass.Daniel,
            Details = "Specializes in finding Granilla Bars in gradmas glade. Has a small chance to harvest them."
        };
        benefit = new()
        {
            Worksite = CountryWorksiteListClass.GrandmasGlade,
            Item = CountryItemList.GranillaBars,
            ChanceModifier = granillaChances
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);


        // Worker 5: Extra Trout from Pond
        worker = new()
        {
            WorkerName = CountryWorkerListClass.Ethan,
            Details = "Expert fisherman. Guarantees one extra trout from the pond and gives one extra blackberry from grandmas glade."
        };
        benefit = new()
        {
            Worksite = CountryWorksiteListClass.Pond,
            Item = CountryItemList.Trout,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = CountryWorksiteListClass.GrandmasGlade,
            Item = CountryItemList.Blackberries,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);

        // Worker 6: Extra Bass from Pond (no chance modifier)
        worker = new WorkerRecipe()
        {
            WorkerName = CountryWorkerListClass.Fiona,
            Details = "Specializes in catching bass at the pond. Gives one bass but does not increase the chances of finding one."
        };
        benefit = new WorkerBenefit()
        {
            Worksite = CountryWorksiteListClass.Pond,
            Item = CountryItemList.Bass,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);

        // Worker 7: Extra Mint chance from Pond
        worker = new()
        {
            WorkerName = CountryWorkerListClass.George,
            Details = "Herbal expert. Increases mint chance at the pond and gives extra blackberries at Grandma’s Glade."
        };
        benefit = new WorkerBenefit()
        {
            Worksite = CountryWorksiteListClass.Pond,
            Item = CountryItemList.Mint,
            ChanceModifier = 0.25    // +25% chance
        };
        worker.Benefits.Add(benefit);
        benefit = new WorkerBenefit()
        {
            Worksite = CountryWorksiteListClass.GrandmasGlade,
            Item = CountryItemList.Blackberries,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        output.Add(worker);
        return output;
    }
}