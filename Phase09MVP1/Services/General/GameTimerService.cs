namespace Phase09MVP1.Services.General;
public class GameTimerService(IStartFarmRegistry farmRegistry,
    IInventoryPersistence inventoryPersistence,
    IBaseBalanceProvider baseBalanceProvider,
    GameRegistry gameRegistry, IServiceProvider sp) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        BasicList<FarmKey> firsts = await farmRegistry.GetFarmsAsync();
        foreach (var farm in firsts)
        {
            //could create a factory to produce this.
            //here will need to figure out the interface for this.
            

            Inventory inventory = new(farm, inventoryPersistence);
            IStartingFactory starts = sp.GetRequiredService<IStartingFactory>();
            ICropFactory cropFactory = sp.GetRequiredService<ICropFactory>();
            ITreeFactory treeFactory = sp.GetRequiredService<ITreeFactory>();
            IAnimalFactory animalFactory = sp.GetRequiredService<IAnimalFactory>();
            IWorkshopFactory workshopFactory = sp.GetRequiredService<IWorkshopFactory>();
            IWorksiteFactory worksiteFactory = sp.GetRequiredService<IWorksiteFactory>();
            IWorkerFactory workerFactory = sp.GetRequiredService<IWorkerFactory>();
            IQuestFactory questFactory = sp.GetRequiredService<IQuestFactory>();
            CropManager cropManager = new(inventory, baseBalanceProvider);
            TreeManager treeManager = new(inventory, baseBalanceProvider);
            AnimalManager animalManager = new(inventory, baseBalanceProvider);
            WorkshopManager workshopManager = new(inventory, baseBalanceProvider);
            WorksiteManager worksiteManager = new(inventory, baseBalanceProvider);
            QuestManager questManager = new(inventory);
            IGameTimer timer = new BasicGameState(
                inventory, starts,
                cropFactory, treeFactory, animalFactory, workshopFactory,
                worksiteFactory, workerFactory, questFactory,
                cropManager, treeManager, animalManager, 
                workshopManager, worksiteManager, questManager
                );
            await gameRegistry.InitializeFarmAsync(timer, farm);
        }
        await base.StartAsync(cancellationToken);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await gameRegistry.TickAsync();
            }
            catch
            {
                // ignore
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}