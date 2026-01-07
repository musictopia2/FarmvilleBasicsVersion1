namespace Phase07Images.Services.Animals;
public interface IAnimalPersistence
{
    Task SaveAnimalsAsync(BasicList<AnimalAutoResumeModel> animals);
}