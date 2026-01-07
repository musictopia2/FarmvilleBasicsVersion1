namespace Phase18SampleUpgrades;
public static class ServiceExtensions
{
    extension (IServiceCollection services)
    {
        public IServiceCollection RegisterFarmServices()
        {
            services.AddHostedService<GameTimerService>()
                .AddSingleton<IGameTimer, BasicGameState>()
                .AddSingleton<Inventory>()
                .AddSingleton<IStartingInventoryProvider, BasicStartingInventoryClass>()
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
                .AddSingleton<ITreeRecipes, TreeRecipesRegistry>()
                .AddSingleton<ITreeInstances, TreeInstances>()
                .AddSingleton<ITreesCollecting, DefaultTreesCollected>()
                .AddSingleton<ITreePolicy, TreePolicy>()
                ;
            return services;
        }
        private IServiceCollection RegisterCropServices()
        {
            services.AddSingleton<CropManager>()
                .AddSingleton<ICropInstances, CropInstances>()
                .AddSingleton<ICropRegistry, CropRegistry>()
                .AddSingleton<ICropPolicy, CropPolicy>()
                ;
            return services;
        }
        private IServiceCollection RegisterAnimalServices()
        {
            services.AddSingleton<AnimalManager>()
                .AddSingleton<IAnimalRegistry, AnimalRecipesRegistry>()
                .AddSingleton<IAnimalInstances, AnimalInstances>()
                .AddSingleton<IAnimalPolicy, AnimalPolicy>()
                ;
            return services;
        }
        private IServiceCollection RegisterWorkshopServices()
        {
            services.AddSingleton<WorkshopManager>()
                .AddSingleton<IWorkshopRegistry, WorkshopRecipesRegistry>()
                .AddSingleton<IWorkshopInstances, WorkshopInstances>()
                .AddSingleton<IWorkshopPolicy, WorkshopPolicy>();
            return services;
        }
        private IServiceCollection RegisterWorksiteServices()
        {
            services.AddSingleton<WorksiteManager>()
                .AddSingleton<IWorksiteRegistry, WorksitesRegistry>()
                .AddSingleton<IWorksiteInstances, WorksiteInstances>()
                .AddSingleton<IWorkerRegistry, WorkersRegistry>()
                .AddSingleton<IWorksitePolicy, WorksitePolicy>()
                .AddSingleton<IWorkerInstances, WorkerInstances>()
                .AddSingleton<IWorkerPolicy, WorkerPolicy>()
                ;
            return services;
        }
        private IServiceCollection RegisterQuestServices()
        {
            services.AddSingleton<QuestManager>();
            return services;
        }
    }
}