
namespace Phase04Part1AdvancedCrafting.Components.Custom;
public partial class MainComponent
{
    //no need for separate view models yet.

    EnumUIStatus _status = EnumUIStatus.None;

    private bool CanGoBack => _status != EnumUIStatus.None;

    private void GoBack()
    {
        _status = EnumUIStatus.None;
    }
    private void OpenPastryOven()
    {
        _status = EnumUIStatus.BuildingPastryOven;
    }
    private void OpenWindmill()
    {
        _status |= EnumUIStatus.BuildingWindmill;
    }
    private string Title
    {
        get
        {
            if (_status == EnumUIStatus.None)
            {
                return "Main Page";
            }
            if (_status == EnumUIStatus.BuildingPastryOven)
            {
                return "Pastry Oven";
            }
            if (_status == EnumUIStatus.BuildingWindmill)
            {
                return "Windmill";
            }
            throw new CustomBasicException("Nothing Found");
        }
    }

}