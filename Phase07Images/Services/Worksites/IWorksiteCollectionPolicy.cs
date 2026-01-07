namespace Phase07Images.Services.Worksites;
public interface IWorksiteCollectionPolicy
{
    Task<bool> CollectAllAsync();
}