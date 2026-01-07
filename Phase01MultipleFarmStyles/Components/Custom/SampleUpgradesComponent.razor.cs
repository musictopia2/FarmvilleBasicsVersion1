namespace Phase01MultipleFarmStyles.Components.Custom;
public partial class SampleUpgradesComponent(WorkshopManager workshopManager,
    AnimalManager animalManager,
    CropManager cropManager,
    TreeManager treeManager,
    WorksiteManager worksiteManager,
    IToast toast
    )
{
    private bool _canUnlockPastryOven = false;
    private bool _canUnlockAnotherWindmill = false;
    private bool _canLockWindmill = false;
    private bool _canUnlockPeachTree = false;
    private bool _canUnlockAnotherAppleTree = false;
    private bool _canLockAppleTree = false;



    private bool _canUnlockAnotherCow = false;
    private bool _canUnlockChicken = false;
    private bool _canLockCow = false;

    private bool _canIncreaseCowOptions = false;
    private bool _canDecreaseCowOptions = false;
    private bool _canIncreaseChickenOptions = false;
    private bool _canDecreaseChickenOptions = false;

    private bool _canUnlockCorn = false;
    private bool _canLockCorn = false;
    private bool _canUnlockWheat = false;
    private bool _canLockWheat = false;
    private bool _canUnlock3Slots = false;
    private bool _canLockSlots = false;

    private bool _canUnlockGrandmasGlade = false;
    private bool _canLockGrandmasGlade = false;
    private bool _canUnlockPond = false;
    private bool _canLockPond = false;

    private bool _canUnlockToby = false;
    private bool _canLockToby= false;
    private bool _canUnlockBob = false;
    private bool _canLockBob = false;
    private bool _canUnlockDaniel = false;
    private bool _canLockDaniel = false;
    private bool _canLockAlice = false;

    private async Task RefreshWorksitesAsync()
    {
        _canUnlockGrandmasGlade = await worksiteManager.CanUnlockWorksiteAsync(CountryWorksiteListClass.GrandmasGlade);
        _canLockGrandmasGlade = await worksiteManager.CanLockWorksiteAsync(CountryWorksiteListClass.GrandmasGlade);
        _canUnlockPond = await worksiteManager.CanUnlockWorksiteAsync(CountryWorksiteListClass.Pond);
        _canLockPond = await worksiteManager.CanLockWorksiteAsync(CountryWorksiteListClass.Pond);
        await RefreshWorkersAsync();
    }
    private async Task RefreshWorkersAsync()
    {
        _canUnlockToby = await worksiteManager.CanUnlockWorkerAsync(CountryWorkerListClass.Toby);
        _canLockToby = await worksiteManager.CanLockWorkerAsync(CountryWorkerListClass.Toby);
        _canUnlockBob = await worksiteManager.CanUnlockWorkerAsync(CountryWorkerListClass.Bob);
        _canLockBob = await worksiteManager.CanLockWorkerAsync(CountryWorkerListClass.Bob);
        _canUnlockDaniel = await worksiteManager.CanUnlockWorkerAsync(CountryWorkerListClass.Daniel);
        _canLockDaniel = await worksiteManager.CanLockWorkerAsync(CountryWorkerListClass.Daniel);
        _canLockAlice = await worksiteManager.CanLockWorkerAsync(CountryWorkerListClass.Alice);
    }
    private async Task UnlockDanielAsync()
    {
        await worksiteManager.UnlockWorkerAsync(CountryWorkerListClass.Daniel);
        await RefreshWorkersAsync();
    }
    private async Task LockDanielAsync()
    {
        await worksiteManager.LockWorkerAsync(CountryWorkerListClass.Daniel);
        await RefreshWorkersAsync();
    }
    private async Task UnlockBobAsync()
    {
        await worksiteManager.UnlockWorkerAsync(CountryWorkerListClass.Bob);
        await RefreshWorkersAsync();
    }
    private async Task LockBobAsync()
    {
        await worksiteManager.LockWorkerAsync(CountryWorkerListClass.Bob);
        await RefreshWorkersAsync();
    }
    private async Task UnlockTobyAsync()
    {
        await worksiteManager.UnlockWorkerAsync(CountryWorkerListClass.Toby);
        await RefreshWorkersAsync();
    }
    private async Task LockTobyAsync()
    {
        await worksiteManager.LockWorkerAsync(CountryWorkerListClass.Toby);
        await RefreshWorkersAsync();
    }
    private async Task LockAliceAsync()
    {
        await worksiteManager.LockWorkerAsync(CountryWorkerListClass.Alice);
        await RefreshWorkersAsync();
    }
    private async Task UnlockGrandmasGladeAsync()
    {
        await worksiteManager.UnlockWorksiteAsync(CountryWorksiteListClass.GrandmasGlade);
        await RefreshWorksitesAsync();
    }
    private async Task LockGrandmasGladeAsync()
    {
        await worksiteManager.LockWorksiteAsync(CountryWorksiteListClass.GrandmasGlade);
        await RefreshWorksitesAsync();
    }
    private async Task UnlockPondAsync()
    {
        await worksiteManager.UnlockWorksiteAsync(CountryWorksiteListClass.Pond);
        await RefreshWorksitesAsync();
    }
    private async Task LockPondAsync()
    {
        await worksiteManager.LockWorksiteAsync(CountryWorksiteListClass.Pond);
    }

    private async Task RefreshTreesAsync()
    {
        _canUnlockPeachTree = await treeManager.CanUnlockTreeAsync(CountryTreeListClass.Peach);
        _canUnlockAnotherAppleTree = await treeManager.CanUnlockTreeAsync(CountryTreeListClass.Apple);
        _canLockAppleTree = await treeManager.CanLockTreeAsync(CountryTreeListClass.Apple);
    }

    private async Task RefreshCropsAsync()
    {
        _canUnlockCorn = await cropManager.CanUnlockCropAsync(CountryItemList.Corn);
        _canLockCorn = await cropManager.CanLockCropAsync(CountryItemList.Corn);
        _canUnlockWheat = await cropManager.CanUnlockCropAsync(CountryItemList.Wheat);
        _canLockWheat = await cropManager.CanLockCropAsync(CountryItemList.Wheat);
        _canUnlock3Slots = await cropManager.CanUnlockGrowSlotsAsync(3);
        _canLockSlots = await cropManager.CanLockGrowSlotsAsync();
    }
    private async Task UnlockCornAsync()
    {
        await cropManager.UnlockCropAsync(CountryItemList.Corn);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task LockCornAsync()
    {
        await cropManager.LockCropAsync(CountryItemList.Corn);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task UnlockWheatAsync()
    {
        await cropManager.UnlockCropAsync(CountryItemList.Wheat);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task LockWheatAsync()
    {
        await cropManager.LockCropAsync(CountryItemList.Wheat);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task Unlock3SlotsAsync()
    {
        await cropManager.UnlockGrowSlotsAsync(3);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task LockSlotsAsync()
    {
        await cropManager.LockGrowSlotsAsync();
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task RefreshWorkshopUnlockAsync()
    {
        _canUnlockPastryOven = await workshopManager.CanUnlockWorkshopAsync(CountryWorkshopList.PastryOven);
        _canUnlockAnotherWindmill = await workshopManager.CanUnlockWorkshopAsync(CountryWorkshopList.Windill);
        _canLockWindmill = await workshopManager.CanLockWorkshopAsync(CountryWorkshopList.Windill);
    }
    private async Task RefreshAnimalsAsync()
    {
        _canUnlockChicken = await animalManager.CanUnlockAnimalAsync(CountryAnimalListClass.Chicken);
        _canUnlockAnotherCow = await animalManager.CanUnlockAnimalAsync(CountryAnimalListClass.Cow);
        _canLockCow = await animalManager.CanLockAnimalAsync(CountryAnimalListClass.Cow);
        _canIncreaseChickenOptions = await animalManager.CanIncreaseAnimalOptionsAsync(CountryAnimalListClass.Chicken);
        _canDecreaseChickenOptions = await animalManager.CanDecreaseAnimalOptionsAsync(CountryAnimalListClass.Chicken);
        _canIncreaseCowOptions = await animalManager.CanIncreaseAnimalOptionsAsync(CountryAnimalListClass.Cow);
        _canDecreaseCowOptions = await animalManager.CanDecreaseAnimalOptionsAsync(CountryAnimalListClass.Cow);
    }
    protected override async Task OnInitializedAsync()
    {
        await RefreshAllAsync();
    }
    private async Task UnlockWindmillAsync()
    {
        await workshopManager.UnlockWorkshopAsync(CountryWorkshopList.Windill);
        await RefreshWorkshopUnlockAsync();
    }
    private async Task UnlockPastryOvenAsync()
    { 
        await workshopManager.UnlockWorkshopAsync(CountryWorkshopList.PastryOven);
        await RefreshWorkshopUnlockAsync();
    }
    private async Task LockWindmillAsync()
    {
        await workshopManager.LockWorkshopAsync(CountryWorkshopList.Windill);
        await RefreshWorkshopUnlockAsync();
    }
    private async Task UnlockPeachTreeAsync()
    {
        await treeManager.UnlockTreeAsync(CountryTreeListClass.Peach);
        await RefreshTreesAsync();
    }
    private async Task UnlockAppleTreeAsync()
    {
        await treeManager.UnlockTreeAsync(CountryTreeListClass.Apple);
        await RefreshTreesAsync();
    }
    private async Task LockAppleTreeAsync()
    {
        await treeManager.LockTreeAsync(CountryTreeListClass.Apple);
        await RefreshTreesAsync();
    }
    private async Task UnlockCowAsync()
    {
        await animalManager.UnlockAnimalAsync(CountryAnimalListClass.Cow);
        await RefreshAnimalsAsync();
    }
    private async Task UnlockChickenAsync()
    {
        await animalManager.UnlockAnimalAsync(CountryAnimalListClass.Chicken);
        await RefreshAnimalsAsync();
    }
    private async Task LockCowAsync()
    {
        await animalManager.LockAnimalAsync(CountryAnimalListClass.Cow);
        await RefreshAnimalsAsync();
    }
    private async Task IncreaseCowOptionsAsync()
    {
        await animalManager.IncreaseAnimalOptionsAsync(CountryAnimalListClass.Cow);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task DecreaseCowOptionsAsync()
    {
        await animalManager.DecreaseAnimalOptionsAsync(CountryAnimalListClass.Cow);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task IncreaseChickenOptionsAsync()
    {
        await animalManager.IncreaseAnimalOptionsAsync(CountryAnimalListClass.Chicken);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task DecreaseChickenOptionsAsync()
    {
        await animalManager.DecreaseAnimalOptionsAsync(CountryAnimalListClass.Chicken);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task RefreshAllAsync()
    {
        await RefreshWorkshopUnlockAsync();
        await RefreshAnimalsAsync();
        await RefreshCropsAsync();
        await RefreshTreesAsync();
        await RefreshWorksitesAsync();
    }
    protected override async Task OnTickAsync()
    {
        await RefreshAllAsync();
        await base.OnTickAsync();
    }
}