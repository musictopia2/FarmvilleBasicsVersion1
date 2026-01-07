namespace Phase09MVP1.Services.Animals;
public interface IAnimalPersistence
{
    Task SaveAnimalsAsync(BasicList<AnimalAutoResumeModel> animals);
}