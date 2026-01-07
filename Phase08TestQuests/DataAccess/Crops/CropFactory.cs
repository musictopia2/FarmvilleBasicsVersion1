namespace Phase08TestQuests.DataAccess.Crops;
public class CropFactory : ICropFactory
{
    CropServicesContext ICropFactory.GetCropServices(PlayerState player)
    {
   
        ICropHarvestPolicy collection;
        if (player.SessionMode == SessionModeList.SimpleTesting)
        {
            collection = new CropManualHarvestPolicy();
        }
        else
        {
            collection = new CropManualHarvestPolicy();
        }
        ICropRegistry register;
        register = new CropRecipeDatabase(player);
        CropInstanceDatabase db = new(player, register);
        CropServicesContext output = new()
            {
                CropHarvestPolicy = collection,
                CropProgressionPolicy = new BasicCropPolicy(),
                CropRegistry  = register,
                CropInstances  = db,
                CropPersistence = db
            };
        return output;
    }
}