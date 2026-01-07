namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.General;
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
    WorksiteManager worksiteManager,
    PlayerState playerState
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
    async Task IGameTimer.SetStyleContextAsync()
    {
        if (string.IsNullOrWhiteSpace(playerState.PlayerName) || string.IsNullOrWhiteSpace(playerState.FarmTheme))
        {
            throw new CustomBasicException("Must specify player and farm styles now");
        }
        IStartingInventoryProvider init = startFactory.GetInventoryServices();
        Dictionary<string, int> starts = await init.GetStartingInventoryAsync();
        inventory.LoadStartingInventory(starts);
        CropServicesContext cropContext = cropFactory.GetCropServices();
        await cropManager.SetStyleContextAsync(cropContext);
        TreeServicesContext treeContext = treeFactory.GetTreeServices();
        await treeManager.SetStyleContextAsync(treeContext);
        AnimalServicesContext animalContext = animalFactory.GetAnimalServices();
        await animalManager.SetStyleContextAsync(animalContext);
        WorkshopServicesContext workshopContext = workshopFactory.GetWorkshopServices();
        await workshopManager.SetStyleContextAsync(workshopContext);
        WorksiteServicesContext worksiteContext = worksiteFactory.GetWorksiteServices();
        WorkerServicesContext workerContext = workerFactory.GetWorkerServices();
        await worksiteManager.SetStyleContextAsync(worksiteContext, workerContext);
        _init = true;
    }
}