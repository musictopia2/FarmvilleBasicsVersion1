namespace Phase04CollectionProcesses.Data.General;
public class StartingFactory : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices(PlayerState player)
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return new CountryBasicStartingInventoryClass();
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return new TropicalBasicStartingInventoryClass();
        }
        throw new CustomBasicException("Not supported");
    }
}