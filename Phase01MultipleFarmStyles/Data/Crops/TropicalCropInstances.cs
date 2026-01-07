namespace Phase01MultipleFarmStyles.Data.Crops;
public class TropicalCropInstances(ICropRegistry registry) : ICropInstances
{
    async Task<CropSystemState> ICropInstances.GetCropInstancesAsync()
    {
        CropSystemState output = new();
        var list = await registry.GetCropsAsync();
        foreach (var item in list)
        {
            bool unlocked;
            if (item.Item == TropicalItemList.Pineapples)
            {
                unlocked = true;
            }
            else
            {
                unlocked = false; //for testing
            }
            CropDataModel crop = new()
            {
                Item = item.Item,
                Unlocked = unlocked
            };
            output.Crops.Add(crop);
        }
        24.Times(x =>
        {
            bool unlocked;
            if (x <= 8)
            {
                unlocked = true;
            }
            else
            {
                unlocked = false;
            }
            GrowSlot grow = new()
            {
                Unlocked = unlocked
            };
            output.Slots.Add(grow);
        });
        return output;
    }
}