namespace Phase16FirstSimpleQuests.Services;
public class WorkerRegistry
{
    private BasicList<WorkerModel> _workers = [];
    public WorkerRegistry()
    {
        LoadWorkers();   
    }
    private void LoadWorkers()
    {
        WorkerModel worker = new()
        {
            WorkerName = "Bob",
            Details = "Has high chances of getting chives at grandmas glade and receives one carrot from the pond.   Finally has medium chance of receiving farmers soup in grandmas glade"
        };
        WorkerBenefit benefit = new()
        {
            Worksite = EnumWorksiteLocation.GrandmasGlade,
            Item = EnumItemType.Chives,
            ChanceModifier = 0.3
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = EnumWorksiteLocation.Pond,
            Item = EnumItemType.Carrots,
            Guarantee = true
            //QuantityBonus = 1 //i think is needed
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = EnumWorksiteLocation.GrandmasGlade,
            Item = EnumItemType.FarmersSoup,
            ChanceModifier = 0.6
            //QuantityBonus = 1 //i think is needed
        };
        worker.Benefits.Add(benefit);
        //try without the bonus (if nothing is given and is not a normal benefit, then needs to be 1).
        _workers.Add(worker);
        worker = new()
        {
            WorkerName = "Alice",
            Details = "General Worker."
        };
        _workers.Add(worker);
        worker = new()
        {
            WorkerName = "Clara",
            Details = "Expert in picking strawberries. Guarantees one strawberry per job in grandmas glade."
        };
        benefit = new()
        {
            Worksite = EnumWorksiteLocation.GrandmasGlade,
            Item = EnumItemType.Strawberries,
            Guarantee = true //must show this or no chances.
            //QuantityBonus = 1 //otherwise no strawberries.
        };
        _workers.Add(worker);
        worker.Benefits.Add(benefit);
        worker = new()
        {
            WorkerName = "Daniel",
            Details = "Specializes in finding Granilla Bars in gradmas glade. Has a small chance to harvest them."
        };
        benefit = new()
        {
            Worksite = EnumWorksiteLocation.GrandmasGlade,
            Item = EnumItemType.GranillaBars,
            ChanceModifier = 0.75 //was 0.15 but had to increase the chances so if i had a quest for it, has to think about how to do it.
        };
        worker.Benefits.Add(benefit);
        _workers.Add(worker);


        // Worker 5: Extra Trout from Pond
        worker = new()
        {
            WorkerName = "Ethan",
            Details = "Expert fisherman. Guarantees one extra trout from the pond and gives one extra blackberry from grandmas glade."
        };
        benefit = new()
        {
            Worksite = EnumWorksiteLocation.Pond,
            Item = EnumItemType.Trout,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        benefit = new()
        {
            Worksite = EnumWorksiteLocation.GrandmasGlade,
            Item = EnumItemType.Blackberries,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        _workers.Add(worker);

        // Worker 6: Extra Bass from Pond (no chance modifier)
        worker = new WorkerModel()
        {
            WorkerName = "Fiona",
            Details = "Specializes in catching bass at the pond. Gives one bass but does not increase the chances of finding one."
        };
        benefit = new WorkerBenefit()
        {
            Worksite = EnumWorksiteLocation.Pond,
            Item = EnumItemType.Bass,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        _workers.Add(worker);

        // Worker 7: Extra Mint chance from Pond
        worker = new()
        {
            WorkerName = "George",
            Details = "Herbal expert. Increases mint chance at the pond and gives extra blackberries at Grandma’s Glade."
        };
        benefit = new WorkerBenefit()
        {
            Worksite = EnumWorksiteLocation.Pond,
            Item = EnumItemType.Mint,
            ChanceModifier = 0.25    // +25% chance
        };
        worker.Benefits.Add(benefit);
        benefit = new WorkerBenefit()
        {
            Worksite = EnumWorksiteLocation.GrandmasGlade,
            Item = EnumItemType.Blackberries,
            GivesExtra = true
        };
        worker.Benefits.Add(benefit);
        _workers.Add(worker);
    }
    public BasicList<WorkerModel> GetAllWorkers => _workers.ToBasicList(); //give a copy
}