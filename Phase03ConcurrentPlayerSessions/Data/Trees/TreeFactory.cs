namespace Phase03ConcurrentPlayerSessions.Data.Trees;
public class TreeFactory : ITreeFactory
{
    TreeServicesContext ITreeFactory.GetTreeServices(PlayerState player)
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return FromCountry(player);
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return FromTropical(player);
        }
        throw new CustomBasicException("Not supported");
    }
    private static TreeServicesContext FromCountry(PlayerState player)
    {
        ITreeRecipes register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new CountryTestTreeRecipesRegistry();
        }
        else
        {
            register = new CountryStandardTreeRecipesRegistry();
        }
        return new()
        {
            TreesCollecting = new DefaultTreesCollected(),
            TreeRegistry = register,
            TreeInstances = new BasicTreeInstances(register),
            TreePolicy = new BasicTreePolicy(),
        };
    }
    private static TreeServicesContext FromTropical(PlayerState player)
    {
        ITreeRecipes register;
        if (player.SessionMode == SessionModeList.TestQuests || player.SessionMode == SessionModeList.SimpleTesting)
        {
            register = new TropicalTestTreeRecipesRegistry();
        }
        else
        {
            register = new TropicalStandardTreeRecipesRegistry();
        }
        return new()
        {
            TreesCollecting = new DefaultTreesCollected(),
            TreeRegistry = register,
            TreeInstances = new BasicTreeInstances(register),
            TreePolicy = new BasicTreePolicy(),
        };
    }
}