namespace Phase08TestQuests.Services.General;
public class MainFarmContainer
{
    required public CropManager CropManager { get; set; }
    required public TreeManager TreeManager { get; set; }
    required public Inventory Inventory { get; set; }
    required public AnimalManager AnimalManager { get; set; }
    required public WorkshopManager WorkshopManager { get; set; }
    required public WorksiteManager WorksiteManager { get; set; }
    required public QuestManager QuestManager { get; set; }
}