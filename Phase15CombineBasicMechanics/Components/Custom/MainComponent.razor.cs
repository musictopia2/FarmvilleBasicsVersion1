namespace Phase15CombineBasicMechanics.Components.Custom;
public partial class MainComponent
{
    EnumUIStatus _status = EnumUIStatus.None;
    private bool CanGoBack => _status != EnumUIStatus.None;
    private void GoBack()
    {
        _status = EnumUIStatus.None;
    }
    private void OpenGrandmasGlade()
    {
        _status = EnumUIStatus.WorksiteGrandmasGlade;
    }
    private void OpenPond()
    {
        _status = EnumUIStatus.WorksitePond;
    }
    private void OpenCow()
    {
        _status = EnumUIStatus.Cow;
    }
    private void OpenChicken()
    {
        _status = EnumUIStatus.Chicken;
    }
    private void OpenAppleTrees()
    {
        _status = EnumUIStatus.AppleTrees;
    }
    private void OpenPeachTrees()
    {
        _status = EnumUIStatus.PeachTrees;
    }
    private void OpenPastryOven()
    {
        _status = EnumUIStatus.BuildingPastryOven;
    }
    private void OpenWindmill()
    {
        _status = EnumUIStatus.BuildingWindmill;
    }
    private void OpenCrops()
    {
        _status = EnumUIStatus.Crops;
    }
    private string Title
    {
        get
        {
            if (_status == EnumUIStatus.None)
            {
                return "Main Page";
            }
            if (_status == EnumUIStatus.WorksiteGrandmasGlade)
            {
                return "Grandmas Glade";
            }
            if (_status == EnumUIStatus.WorksitePond)
            {
                return "Pond";
            }
            if (_status == EnumUIStatus.BuildingPastryOven)
            {
                return "Pastry Oven";
            }
            if (_status == EnumUIStatus.BuildingWindmill)
            {
                return "Windmill";
            }
            if (_status == EnumUIStatus.Crops)
            {
                return "Crops";
            }
            if (_status == EnumUIStatus.Cow)
            {
                return "Cow";
            }
            if (_status == EnumUIStatus.Chicken)
            {
                return "Chicken";
            }
            if (_status == EnumUIStatus.AppleTrees)
            {
                return "Apple Trees";
            }
            if (_status == EnumUIStatus.PeachTrees)
            {
                return "Peach Trees";
            }
            throw new CustomBasicException("Nothing Found");
        }
    }
}