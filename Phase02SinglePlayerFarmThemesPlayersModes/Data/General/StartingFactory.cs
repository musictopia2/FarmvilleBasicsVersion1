namespace Phase02SinglePlayerFarmThemesPlayersModes.Data.General;
public class StartingFactory(PlayerState player) : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices()
    {
        if (player.FarmTheme == FarmThemeList.Country)
        {
            return new CountryBasicStartingInventoryClass(player);
        }
        if (player.FarmTheme == FarmThemeList.Tropical)
        {
            return new TropicalBasicStartingInventoryClass(player);
        }
        throw new CustomBasicException("Not supported");
    }
}