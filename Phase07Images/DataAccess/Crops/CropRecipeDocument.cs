namespace Phase07Images.DataAccess.Crops;
public class CropRecipeDocument
{
    required
    public string Item { get; init; }
    public TimeSpan Duration { get; init; }
    required
    public string Theme { get; init; }
    required
    public string Mode { get; init; }
}