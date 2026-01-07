namespace Phase04CollectionProcesses.Data.Crops;
public class BasicCropInstances(ICropRegistry registry) : ICropInstances
{
    async Task<CropSystemState> ICropInstances.GetCropInstancesAsync()
    {
        CropSystemState output = new();
        var list = await registry.GetCropsAsync();
        //i already proved in earlier phases can lock/unlock when needed.
        //now need to focus on other things instead.
        foreach (var item in list)
        {
            CropDataModel crop = new()
            {
                Item = item.Item,
                Unlocked = true
            };
            output.Crops.Add(crop);
        }
        15.Times(x =>
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