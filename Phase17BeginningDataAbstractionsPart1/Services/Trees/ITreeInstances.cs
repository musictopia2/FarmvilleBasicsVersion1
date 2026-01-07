namespace Phase17BeginningDataAbstractionsPart1.Services.Trees;
public interface ITreeInstances
{
    Task<BasicList<string>> GetTreeInstancesAsync();
}