namespace Phase06Autoresume.Services.Animals;
public interface IAnimalPersistence
{
    Task SaveAnimalsAsync(BasicList<AnimalAutoResumeModel> animals);
}