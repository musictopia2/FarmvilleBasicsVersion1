using Phase08TestQuests.DataAccess.Animals;
using Phase08TestQuests.DataAccess.Crops;
using Phase08TestQuests.DataAccess.Quests; //not common enough.
using Phase08TestQuests.DataAccess.Trees;
using Phase08TestQuests.DataAccess.Workers;
using Phase08TestQuests.DataAccess.Workshops;
using Phase08TestQuests.DataAccess.Worksites;
//these was not common enough to put into global usings.

namespace Phase08TestQuests;
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
                .AddSingleton<IWorkerFactory, WorkerFactory>()
                .AddSingleton<IQuestFactory, QuestFactory>()
                ;
            return services;
        }
        //not sure about quests.  not until near the end
    }
}