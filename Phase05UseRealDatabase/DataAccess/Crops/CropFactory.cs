namespace Phase05UseRealDatabase.DataAccess.Crops;
public class CropFactory : ICropFactory
{
    CropServicesContext ICropFactory.GetCropServices(PlayerState player)
    {
   
        ICropHarvestPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new CropAutomatedHarvestPolicy();
        }
        else
        {
            collection = new CropManualHarvestPolicy();
        }
        ICropRegistry register;
        register = new CropRecipeDatabase(player);
        CropServicesContext output = new()
            {
                CropHarvestPolicy = collection,
                CropProgressionPolicy = new BasicCropPolicy(),
                CropRegistry  = register,
                CropInstances  = new CropInstanceDatabase(player, register)
            };
        return output;
    }
}