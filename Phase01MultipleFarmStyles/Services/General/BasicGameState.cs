namespace Phase01MultipleFarmStyles.Services.General;
public class BasicGameState(Inventory inventory,
    IStartingFactory startFactory,
    ICropFactory cropFactory,
    ITreeFactory treeFactory,
    IAnimalFactory animalFactory,
    IWorkshopFactory workshopFactory,
    IWorksiteFactory worksiteFactory,
    IWorkerFactory workerFactory,
    CropManager cropManager,
    TreeManager treeManager,
    AnimalManager animalManager,
    WorkshopManager workshopManager,
    WorksiteManager worksiteManager
    //QuestManager quests,
    ) : IGameTimer
{
    private bool _init = false;
    void IGameTimer.Tick()
    {
        if (_init == false)
        {
            return;
        }
        treeManager.UpdateTick();
        cropManager.UpdateTick();
        animalManager.UpdateTick();
        workshopManager.UpdateTick();
        worksiteManager.UpdateTick();
    }
    async Task IGameTimer.SetStyleContextAsync(string style)
    {
        IStartingInventoryProvider init = startFactory.GetInventoryServices(style);
        Dictionary<string, int> starts = await init.GetStartingInventoryAsync();
        inventory.LoadStartingInventory(starts);
        CropServicesContext cropContext = cropFactory.GetCropServices(style);
        await cropManager.SetStyleContextAsync(cropContext);
        TreeServicesContext treeContext = treeFactory.GetTreeServices(style);
        await treeManager.SetStyleContextAsync(treeContext);
        AnimalServicesContext animalContext = animalFactory.GetAnimalServices(style);
        await animalManager.SetStyleContextAsync(animalContext);
        WorkshopServicesContext workshopContext = workshopFactory.GetWorkshopServices(style);
        await workshopManager.SetStyleContextAsync(workshopContext);
        WorksiteServicesContext worksiteContext = worksiteFactory.GetWorksiteServices(style);
        WorkerServicesContext workerContext = workerFactory.GetWorkerServices(style);
        await worksiteManager.SetStyleContextAsync(worksiteContext, workerContext);
        _init = true;
    }
}