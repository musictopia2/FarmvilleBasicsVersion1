namespace Phase04CollectionProcesses.Services.General;
public class GameTimerService(IStartFarmRegistry farmRegistry,
    GameRegistry gameRegistry, IServiceProvider sp) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        BasicList<PlayerState> firsts = await farmRegistry.GetFarmsAsync();
        foreach (var player in firsts)
        {
            //could create a factory to produce this.
            Inventory inventory = new();
            IStartingFactory starts = sp.GetRequiredService<IStartingFactory>();
            ICropFactory cropFactory = sp.GetRequiredService<ICropFactory>();
            ITreeFactory treeFactory = sp.GetRequiredService<ITreeFactory>();
            IAnimalFactory animalFactory = sp.GetRequiredService<IAnimalFactory>();
            IWorkshopFactory workshopFactory = sp.GetRequiredService<IWorkshopFactory>();
            IWorksiteFactory worksiteFactory = sp.GetRequiredService<IWorksiteFactory>();
            IWorkerFactory workerFactory = sp.GetRequiredService<IWorkerFactory>();
            CropManager cropManager = new(inventory);
            TreeManager treeManager = new(inventory);
            AnimalManager animalManager = new(inventory);
            WorkshopManager workshopManager = new(inventory);
            WorksiteManager worksiteManager = new(inventory);
            IGameTimer timer = new BasicGameState(
                inventory, starts,
                cropFactory, treeFactory, animalFactory, workshopFactory, worksiteFactory, workerFactory,
                cropManager, treeManager, animalManager, workshopManager, worksiteManager
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