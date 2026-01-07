namespace Phase07Images.DataAccess.Trees;
public class TreeFactory : ITreeFactory
{
    TreeServicesContext ITreeFactory.GetTreeServices(PlayerState player)
    {
        ITreeGatheringPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new TreeGatherAllPolicy();
        }
        else
        {
            collection = new TreeGatherOneByOnePolicy();
        }
        ITreeRecipes register;
        register = new TreeRecipeDatabase(player);
        TreeInstanceDatabase instance = new TreeInstanceDatabase(player);
        TreeServicesContext output = new()
        {
            TreeGatheringPolicy = collection,
            TreeProgressionPolicy = new BasicTreePolicy(),
            TreeRegistry = register,
            TreeInstances = instance,
            TreesCollecting = new DefaultTreesCollected(),
            TreePersistence = instance
        };
        return output;
    }   
}