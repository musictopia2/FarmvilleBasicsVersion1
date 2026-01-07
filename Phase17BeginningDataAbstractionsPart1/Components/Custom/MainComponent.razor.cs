namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class MainComponent
{
    private bool CanGoBack
    {
        get
        {
            if (_cropsLoaded)
            {
                return true;
            }
            if (_currentWorksite != "")
            {
                return true;
            }
            if (_currentWorkshop is not null)
            {
                return true;
            }
            return false;
        }
    }
    //private bool CanGoBack => _currentWorksite != "" && _currentWorkshop is not null && _cropsLoaded == false;
    private WorkshopSummary? _currentWorkshop;
    private string _currentWorksite = "";
    private bool _cropsLoaded = false;
    private void GoBack()
    {
        _currentWorkshop = null;
        _currentWorksite = "";
        _cropsLoaded = false;
    }
    private void LoadCrops()
    {
        _cropsLoaded = true;
    }
    private void OpenWorksite(string worksite)
    {
        _currentWorksite = worksite;
    }
    private void OpenWorkshop(WorkshopSummary workshop)
    {
        _currentWorkshop = workshop;
    }
    private string Title
    {
        get
        {
            if (_currentWorkshop is not null)
            {
                return _currentWorkshop.Name;
            }
            else if (_currentWorksite != "")
            {
                return _currentWorksite;
            }
            else
            {
                return "Main Page";
            }
        }
    }
}