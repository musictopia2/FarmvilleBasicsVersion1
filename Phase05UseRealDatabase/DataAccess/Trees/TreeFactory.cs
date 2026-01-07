namespace Phase05UseRealDatabase.DataAccess.Trees;
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
        TreeServicesContext output = new()
        {
            TreeGatheringPolicy = collection,
            TreeProgressionPolicy = new BasicTreePolicy(),
            TreeRegistry = register,
            TreeInstances = new TreeInstanceDatabase(player, register),
            TreesCollecting = new DefaultTreesCollected(),
        };
        return output;
    }   
}