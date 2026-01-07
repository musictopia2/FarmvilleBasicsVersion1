namespace Phase02SinglePlayerFarmThemesPlayersModes;
public static class ServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterFarmServices()
        {
            services.AddHostedService<GameTimerService>()
                .AddSingleton<IGameTimer, BasicGameState>()
                .AddSingleton<PlayerState>()
                .AddSingleton<Inventory>()
                .AddSingleton<IStartingFactory, StartingFactory>()
                .RegisterTreeServices()
                .RegisterCropServices()
                .RegisterAnimalServices()
                .RegisterWorkshopServices()
                .RegisterWorksiteServices()
                .RegisterQuestServices();
            return services;
        }
        private IServiceCollection RegisterTreeServices()
        {
            services.AddSingleton<TreeManager>()
                .AddSingleton<ITreeFactory, TreeFactory>()
                ;
            return services;
        }
        private IServiceCollection RegisterCropServices()
        {
            services.AddSingleton<CropManager>()
                .AddSingleton<ICropFactory, CropFactory>()
                ;
            return services;
        }
        private IServiceCollection RegisterAnimalServices()
        {
            services.AddSingleton<AnimalManager>()
                .AddSingleton<IAnimalFactory, AnimalFactory>()
                ;
            return services;
        }
        private IServiceCollection RegisterWorkshopServices()
        {
            services.AddSingleton<WorkshopManager>()
                .AddSingleton<IWorkshopFactory, WorkshopFactory>()
                ;
            return services;
        }
        private IServiceCollection RegisterWorksiteServices()
        {
            services.AddSingleton<WorksiteManager>()
                .AddSingleton<IWorksiteFactory, WorksiteFactory>()
                .AddSingleton<IWorkerFactory, WorkerFactory>()
                ;
            return services;
        }
        private IServiceCollection RegisterQuestServices()
        {
            //services.AddSingleton<QuestManager>();
            return services;
        }
    }
}