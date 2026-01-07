namespace Phase03ConcurrentPlayerSessions.Services.General;
public class BasicGameState : IGameTimer
{
    public BasicGameState(Inventory inventory,
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
)
    {
        _inventory = inventory;
        _startFactory = startFactory;
        _cropFactory = cropFactory;
        _treeFactory = treeFactory;
        _animalFactory = animalFactory;
        _workshopFactory = workshopFactory;
        _worksiteFactory = worksiteFactory;
        _workerFactory = workerFactory;
        _cropManager = cropManager;
        _treeManager = treeManager;
        _animalManager = animalManager;
        _workshopManager = workshopManager;
        _worksiteManager = worksiteManager;
        _container = new MainFarmContainer
        {
            Inventory = inventory,
            CropManager = cropManager,
            TreeManager = treeManager,
            AnimalManager = animalManager,
            WorkshopManager = workshopManager,
            WorksiteManager = worksiteManager
        };
    }
    readonly MainFarmContainer _container;
    private readonly Inventory _inventory;
    private readonly IStartingFactory _startFactory;
    private readonly ICropFactory _cropFactory;
    private readonly ITreeFactory _treeFactory;
    private readonly IAnimalFactory _animalFactory;
    private readonly IWorkshopFactory _workshopFactory;
    private readonly IWorksiteFactory _worksiteFactory;
    private readonly IWorkerFactory _workerFactory;
    private readonly CropManager _cropManager;
    private readonly TreeManager _treeManager;
    private readonly AnimalManager _animalManager;
    private readonly WorkshopManager _workshopManager;
    private readonly WorksiteManager _worksiteManager;
    private PlayerState? _player;
    PlayerState? IGameTimer.PlayerState => _player;
    MainFarmContainer IGameTimer.FarmContainer
    {
        get
        {
            return _container;
        }
    }
    private bool _init = false;
    void IGameTimer.Tick()
    {
        if (_init == false)
        {
            return;
        }
        _treeManager.UpdateTick();
        _cropManager.UpdateTick();
        _animalManager.UpdateTick();
        _workshopManager.UpdateTick();
        _worksiteManager.UpdateTick();
    }
    async Task IGameTimer.SetThemeContextAsync(PlayerState player)
    {
        if (string.IsNullOrWhiteSpace(player.PlayerName) || string.IsNullOrWhiteSpace(player.FarmTheme))
        {
            throw new CustomBasicException("Must specify player and farm styles now");
        }
        _player = player;
        IStartingInventoryProvider init = _startFactory.GetInventoryServices(player);
        Dictionary<string, int> starts = await init.GetStartingInventoryAsync(player);
        _inventory.LoadStartingInventory(starts);
        CropServicesContext cropContext = _cropFactory.GetCropServices(player);
        await _cropManager.SetStyleContextAsync(cropContext);
        TreeServicesContext treeContext = _treeFactory.GetTreeServices(player);
        await _treeManager.SetStyleContextAsync(treeContext);
        AnimalServicesContext animalContext = _animalFactory.GetAnimalServices(player);
        await _animalManager.SetStyleContextAsync(animalContext);
        WorkshopServicesContext workshopContext = _workshopFactory.GetWorkshopServices(player);
        await _workshopManager.SetStyleContextAsync(workshopContext);
        WorksiteServicesContext worksiteContext = _worksiteFactory.GetWorksiteServices(player);
        WorkerServicesContext workerContext = _workerFactory.GetWorkerServices(player);
        await _worksiteManager.SetStyleContextAsync(worksiteContext, workerContext);
        _init = true;
    }
}