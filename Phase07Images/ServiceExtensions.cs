using Phase07Images.DataAccess.Animals;
using Phase07Images.DataAccess.Crops;
using Phase07Images.DataAccess.Trees;
using Phase07Images.DataAccess.Workers;
using Phase07Images.DataAccess.Workshops;
using Phase07Images.DataAccess.Worksites;
//these was not common enough to put into global usings.

namespace Phase07Images;
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