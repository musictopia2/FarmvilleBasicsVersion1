namespace Phase18SampleUpgrades.Services.General;
public class BasicGameState(Inventory inventory,
    CropManager crops,
    TreeManager trees,
    AnimalManager animals,
    WorkshopManager workshops,
    WorksiteManager worksites,
    QuestManager quests,
    IStartingInventoryProvider startingInventory
    ) : IGameTimer
{
    async Task IGameTimer.StartAsync()
    {
        await PopulateInventoryAsync();
        await crops.PopulateCropsAsync();
        await trees.PopulateTreesAsync();
        await animals.PopulateAnimalsAsync();
        await workshops.PopulateWorkshopsAsync();
        await worksites.PopulateWorksitesAsync();
        quests.PopulateQuests();
    }
    private async Task PopulateInventoryAsync()
    {
        Dictionary<string, int> starts = await startingInventory.GetStartingInventoryAsync();
        inventory.LoadStartingInventory(starts);
    }
    void IGameTimer.Tick()
    {
        trees.UpdateTick();
        crops.UpdateTick();
        animals.UpdateTick();
        workshops.UpdateTick();
        worksites.UpdateTick();
    }
}