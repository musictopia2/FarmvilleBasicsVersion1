namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.Trees;
public class TreeFactory(PlayerState player) : ITreeFactory
{
    TreeServicesContext ITreeFactory.GetTreeServices()
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return FromCountry();
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return FromTropical();
        }
        throw new CustomBasicException("Not supported");
    }
    private TreeServicesContext FromCountry()
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
    private TreeServicesContext FromTropical()
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