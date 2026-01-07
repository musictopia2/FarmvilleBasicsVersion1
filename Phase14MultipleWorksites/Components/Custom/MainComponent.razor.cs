namespace Phase14MultipleWorksites.Components.Custom;
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
        _status |= EnumUIStatus.WorksitePond;
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
            throw new CustomBasicException("Nothing Found");
        }
    }
}