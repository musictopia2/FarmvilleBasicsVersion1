namespace Phase05UseRealDatabase.Services.Trees;
public class TreeServicesContext
{
    required
    public ITreeRecipes TreeRegistry { get; init; }
    required
    public ITreeInstances TreeInstances { get; init; }
    required
    public ITreeProgressionPolicy TreeProgressionPolicy { get; init; }
    required
    public ITreeGatheringPolicy TreeGatheringPolicy { get; init; }
    required
    public ITreesCollecting TreesCollecting { get; init; }
     
}