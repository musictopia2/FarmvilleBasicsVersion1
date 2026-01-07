namespace Phase01MultipleFarmStyles.Data.Trees;
public class TreeFactory : ITreeFactory
{
    TreeServicesContext ITreeFactory.GetTreeServices(string style)
    {
        if (style == FarmStyleList.Country)
        {
            return FromCountry();
        }
        if (style == FarmStyleList.Tropical)
        {
            return FromTropical();
        }
        throw new CustomBasicException("Not supported");
    }
    private static TreeServicesContext FromCountry()
    {
        ITreeRecipes register = new CountryTreeRecipesRegistry();
        return new()
        {
            TreesCollecting = new DefaultTreesCollected(),
            TreeRegistry = register,
            TreeInstances = new CountryTreeInstances(register),
            TreePolicy = new CountryTreePolicy(),
        };
    }
    private static TreeServicesContext FromTropical()
    {
        ITreeRecipes register = new TropicalTreeRecipesRegistry();
        return new()
        {
            TreesCollecting = new DefaultTreesCollected(),
            TreeRegistry = register,
            TreeInstances = new TropicalTreeInstances(register),
            TreePolicy = new TropicalTreePolicy(),
        };
    }
}