namespace Phase01MultipleFarmStyles.Data.General;
public class StartingFactory : IStartingFactory
{
    IStartingInventoryProvider IStartingFactory.GetInventoryServices(string style)
    {
        if (style == FarmStyleList.Country)
        {
            return new CountryBasicStartingInventoryClass();
        }
        if (style == FarmStyleList.Tropical)
        {
            return new TropicalBasicStartingInventoryClass();
        }
        throw new CustomBasicException("Not supported");
    }   
}