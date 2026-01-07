namespace Phase08TestQuests.Services.General;
public class GameTimerService(IStartFarmRegistry farmRegistry,
    IInventoryPersistence inventoryPersistence,
    GameRegistry gameRegistry, IServiceProvider sp) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        BasicList<PlayerState> firsts = await farmRegistry.GetFarmsAsync();
        foreach (var player in firsts)
        {
            //could create a factory to produce this.
            //here will need to figure out the interface for this.
            

            Inventory inventory = new(player, inventoryPersistence);
            IStartingFactory starts = sp.GetRequiredService<IStartingFactory>();
            ICropFactory cropFactory = sp.GetRequiredService<ICropFactory>();
            ITreeFactory treeFactory = sp.GetRequiredService<ITreeFactory>();
            IAnimalFactory animalFactory = sp.GetRequiredService<IAnimalFactory>();
            IWorkshopFactory workshopFactory = sp.GetRequiredService<IWorkshopFactory>();
            IWorksiteFactory worksiteFactory = sp.GetRequiredService<IWorksiteFactory>();
            IWorkerFactory workerFactory = sp.GetRequiredService<IWorkerFactory>();
            IQuestFactory questFactory = sp.GetRequiredService<IQuestFactory>();
            CropManager cropManager = new(inventory);
            TreeManager treeManager = new(inventory);
            AnimalManager animalManager = new(inventory);
            WorkshopManager workshopManager = new(inventory);
            WorksiteManager worksiteManager = new(inventory);
            QuestManager questManager = new(inventory);
            IGameTimer timer = new BasicGameState(
                inventory, starts,
                cropFactory, treeFactory, animalFactory, workshopFactory,
                worksiteFactory, workerFactory, questFactory,
                cropManager, treeManager, animalManager, 
                workshopManager, worksiteManager, questManager
                );
            await gameRegistry.InitializeFarmAsync(timer, player);
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