namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Trees;
public class TreeServicesContext
{
    required
    public ITreeRecipes TreeRegistry { get; init; }
    required
    public ITreeInstances TreeInstances { get; init; }
    required
    public ITreePolicy TreePolicy { get; init; }
    required
    public ITreesCollecting TreesCollecting { get; init; }
}