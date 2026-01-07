using Phase05UseRealDatabase.DataAccess.Animals;
using Phase05UseRealDatabase.DataAccess.Crops;
using Phase05UseRealDatabase.DataAccess.Trees;
using Phase05UseRealDatabase.DataAccess.Workers;
using Phase05UseRealDatabase.DataAccess.Workshops;
using Phase05UseRealDatabase.DataAccess.Worksites;
//these was not common enough to put into global usings.

namespace Phase05UseRealDatabase;
public static class ServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterFarmServices()
        {
            services.AddHostedService<GameTimerService>()
                .AddSingleton<GameRegistry>()
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