using Phase06Autoresume.DataAccess.Animals;
using Phase06Autoresume.DataAccess.Crops;
using Phase06Autoresume.DataAccess.Trees;
using Phase06Autoresume.DataAccess.Workers;
using Phase06Autoresume.DataAccess.Workshops;
using Phase06Autoresume.DataAccess.Worksites;
//these was not common enough to put into global usings.

namespace Phase06Autoresume;
public static class ServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterFarmServices()
        {
            services.AddHostedService<GameTimerService>()
                .AddSingleton<GameRegistry>()
                .AddSingleton<IInventoryPersistence, InventoryDatabase>()
                .AddSingleton<IStartFarmRegistry, StartFarmDatabase>()
                .AddSingleton<IStartingFactory, StartingFactory>()
                .AddSingleton<ITreeFactory, TreeFactory>()
                .AddSingleton<ICropFactory, CropFactory>()
                .AddSingleton<IAnimalFactory, AnimalFactory>()
                .AddSingleton<IWorkshopFactory, WorkshopFactory>()
                .AddSingleton<IWorksiteFactory, WorksiteFactory>()
                .AddSingleton<IWorkerFactory, WorkerFactory>();
            return services;
        }
        //not sure about quests.  not until near the end
    }
}