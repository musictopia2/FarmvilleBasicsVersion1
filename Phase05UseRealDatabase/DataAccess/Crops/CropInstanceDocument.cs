namespace Phase05UseRealDatabase.DataAccess.Crops;
public class CropInstanceDocument
{
    required
    public int HowMany { get; set; }
    required
    public PlayerState Player { get; set; }
}