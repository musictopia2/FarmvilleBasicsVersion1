namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Crops;
public class CropSystemState
{
    public BasicList<GrowSlot> Slots { get; set; } = [];
    public BasicList<CropDataModel> Crops { get; set; } = [];
}