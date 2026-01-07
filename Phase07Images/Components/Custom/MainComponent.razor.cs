namespace Phase07Images.Components.Custom;
public partial class MainComponent(NavigationManager nav)
{
    private void ChooseAnotherStyle()
    {
        nav.NavigateTo("/");
    }
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
    private EnumCropState GetState(Guid id) => CropManager.GetCropState(id);
    //private bool CanGoBack => _currentWorksite != "" && _currentWorkshop is not null && _cropsLoaded == false;
    private WorkshopView? _currentWorkshop;
    private string _currentWorksite = "";
    private bool _cropsLoaded = false;
    private bool _showBarn = false;
    private bool _showWorkshop = false;
    private bool _showWorksite = false;
    private bool CanCloseWorksiteAutomatically
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_currentWorksite))
            {
                return false;
            }
            EnumWorksiteState status = WorksiteManager.GetStatus(_currentWorksite);
            if (status != EnumWorksiteState.Collecting)
            {
                return true;
            }
            if (WorksiteManager.CanCollectRewards(_currentWorksite))
            {
                return false;
            }
            return true;
        }
    }
    //private EnumWorksiteState Status => WorksiteManager.GetStatus(Location);
    private void ShowBarn()
    {
        _showBarn = true;
    }
    private void CloseBarn()
    {
        _showBarn = false;
    }
    private void CloseWorkshop()
    {
        _showWorkshop = false;
        _currentWorkshop = null;
    }
    private void CloseWorksite()
    {
        _showWorksite = false;
        _currentWorksite = "";
    }


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
        _showWorksite = true;
    }
    private void OpenWorkshop(WorkshopView workshop)
    {
        _currentWorkshop = workshop;
        _showWorkshop = true;
    }
    private string Title
    {
        get
        {
            if (_cropsLoaded)
            {
                return "Crops";
            }
            else
            {
                return "Main Page";
            }
        }
    }
}