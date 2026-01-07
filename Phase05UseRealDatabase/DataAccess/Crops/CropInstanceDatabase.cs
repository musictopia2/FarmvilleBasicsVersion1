namespace Phase05UseRealDatabase.DataAccess.Crops;
public class CropInstanceDatabase(PlayerState player, ICropRegistry recipes) : ListDataAccess<CropInstanceDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, ICropInstances

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "CropInstances";
    async Task<CropSystemState> ICropInstances.GetCropInstancesAsync()
    {
        var list = await recipes.GetCropsAsync();

        CropSystemState output = new();

        var others = await GetDocumentsAsync();
        int maxs = others.Single(x => x.Player.Equals(player)).HowMany;
        foreach (var item in list)
        {
            CropDataModel crop = new()
            {
                Item = item.Item,
                Unlocked = true
            };
            output.Crops.Add(crop);
        }
        maxs.Times(x =>
        {
            GrowSlot grow = new()
            {
                Unlocked = true
            };
            output.Slots.Add(grow);
        });
        return output;
    }
}