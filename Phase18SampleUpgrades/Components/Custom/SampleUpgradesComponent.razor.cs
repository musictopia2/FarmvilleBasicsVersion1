namespace Phase18SampleUpgrades.Components.Custom;
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
        _canUnlockGrandmasGlade = await worksiteManager.CanUnlockWorksiteAsync(WorksiteListClass.GrandmasGlade);
        _canLockGrandmasGlade = await worksiteManager.CanLockWorksiteAsync(WorksiteListClass.GrandmasGlade);
        _canUnlockPond = await worksiteManager.CanUnlockWorksiteAsync(WorksiteListClass.Pond);
        _canLockPond = await worksiteManager.CanLockWorksiteAsync(WorksiteListClass.Pond);
        await RefreshWorkersAsync();
    }
    private async Task RefreshWorkersAsync()
    {
        _canUnlockToby = await worksiteManager.CanUnlockWorkerAsync(WorkerListClass.Toby);
        _canLockToby = await worksiteManager.CanLockWorkerAsync(WorkerListClass.Toby);
        _canUnlockBob = await worksiteManager.CanUnlockWorkerAsync(WorkerListClass.Bob);
        _canLockBob = await worksiteManager.CanLockWorkerAsync(WorkerListClass.Bob);
        _canUnlockDaniel = await worksiteManager.CanUnlockWorkerAsync(WorkerListClass.Daniel);
        _canLockDaniel = await worksiteManager.CanLockWorkerAsync(WorkerListClass.Daniel);
        _canLockAlice = await worksiteManager.CanLockWorkerAsync(WorkerListClass.Alice);
    }
    private async Task UnlockDanielAsync()
    {
        await worksiteManager.UnlockWorkerAsync(WorkerListClass.Daniel);
        await RefreshWorkersAsync();
    }
    private async Task LockDanielAsync()
    {
        await worksiteManager.LockWorkerAsync(WorkerListClass.Daniel);
        await RefreshWorkersAsync();
    }
    private async Task UnlockBobAsync()
    {
        await worksiteManager.UnlockWorkerAsync(WorkerListClass.Bob);
        await RefreshWorkersAsync();
    }
    private async Task LockBobAsync()
    {
        await worksiteManager.LockWorkerAsync(WorkerListClass.Bob);
        await RefreshWorkersAsync();
    }
    private async Task UnlockTobyAsync()
    {
        await worksiteManager.UnlockWorkerAsync(WorkerListClass.Toby);
        await RefreshWorkersAsync();
    }
    private async Task LockTobyAsync()
    {
        await worksiteManager.LockWorkerAsync(WorkerListClass.Toby);
        await RefreshWorkersAsync();
    }
    private async Task LockAliceAsync()
    {
        await worksiteManager.LockWorkerAsync(WorkerListClass.Alice);
        await RefreshWorkersAsync();
    }
    private async Task UnlockGrandmasGladeAsync()
    {
        await worksiteManager.UnlockWorksiteAsync(WorksiteListClass.GrandmasGlade);
        await RefreshWorksitesAsync();
    }
    private async Task LockGrandmasGladeAsync()
    {
        await worksiteManager.LockWorksiteAsync(WorksiteListClass.GrandmasGlade);
        await RefreshWorksitesAsync();
    }
    private async Task UnlockPondAsync()
    {
        await worksiteManager.UnlockWorksiteAsync(WorksiteListClass.Pond);
        await RefreshWorksitesAsync();
    }
    private async Task LockPondAsync()
    {
        await worksiteManager.LockWorksiteAsync(WorksiteListClass.Pond);
    }

    private async Task RefreshTreesAsync()
    {
        _canUnlockPeachTree = await treeManager.CanUnlockTreeAsync(TreeListClass.Peach);
        _canUnlockAnotherAppleTree = await treeManager.CanUnlockTreeAsync(TreeListClass.Apple);
        _canLockAppleTree = await treeManager.CanLockTreeAsync(TreeListClass.Apple);
    }

    private async Task RefreshCropsAsync()
    {
        _canUnlockCorn = await cropManager.CanUnlockCropAsync(ItemList.Corn);
        _canLockCorn = await cropManager.CanLockCropAsync(ItemList.Corn);
        _canUnlockWheat = await cropManager.CanUnlockCropAsync(ItemList.Wheat);
        _canLockWheat = await cropManager.CanLockCropAsync(ItemList.Wheat);
        _canUnlock3Slots = await cropManager.CanUnlockGrowSlotsAsync(3);
        _canLockSlots = await cropManager.CanLockGrowSlotsAsync();
    }
    private async Task UnlockCornAsync()
    {
        await cropManager.UnlockCropAsync(ItemList.Corn);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task LockCornAsync()
    {
        await cropManager.LockCropAsync(ItemList.Corn);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task UnlockWheatAsync()
    {
        await cropManager.UnlockCropAsync(ItemList.Wheat);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task LockWheatAsync()
    {
        await cropManager.LockCropAsync(ItemList.Wheat);
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
        _canUnlockPastryOven = await workshopManager.CanUnlockWorkshopAsync(WorkshopList.PastryOven);
        _canUnlockAnotherWindmill = await workshopManager.CanUnlockWorkshopAsync(WorkshopList.Windill);
        _canLockWindmill = await workshopManager.CanLockWorkshopAsync(WorkshopList.Windill);
    }
    private async Task RefreshAnimalsAsync()
    {
        _canUnlockChicken = await animalManager.CanUnlockAnimalAsync(AnimalListClass.Chicken);
        _canUnlockAnotherCow = await animalManager.CanUnlockAnimalAsync(AnimalListClass.Cow);
        _canLockCow = await animalManager.CanLockAnimalAsync(AnimalListClass.Cow);
        _canIncreaseChickenOptions = await animalManager.CanIncreaseAnimalOptionsAsync(AnimalListClass.Chicken);
        _canDecreaseChickenOptions = await animalManager.CanDecreaseAnimalOptionsAsync(AnimalListClass.Chicken);
        _canIncreaseCowOptions = await animalManager.CanIncreaseAnimalOptionsAsync(AnimalListClass.Cow);
        _canDecreaseCowOptions = await animalManager.CanDecreaseAnimalOptionsAsync(AnimalListClass.Cow);
    }
    protected override async Task OnInitializedAsync()
    {
        await RefreshAllAsync();
    }
    private async Task UnlockWindmillAsync()
    {
        await workshopManager.UnlockWorkshopAsync(WorkshopList.Windill);
        await RefreshWorkshopUnlockAsync();
    }
    private async Task UnlockPastryOvenAsync()
    { 
        await workshopManager.UnlockWorkshopAsync(WorkshopList.PastryOven);
        await RefreshWorkshopUnlockAsync();
    }
    private async Task LockWindmillAsync()
    {
        await workshopManager.LockWorkshopAsync(WorkshopList.Windill);
        await RefreshWorkshopUnlockAsync();
    }
    private async Task UnlockPeachTreeAsync()
    {
        await treeManager.UnlockTreeAsync(TreeListClass.Peach);
        await RefreshTreesAsync();
    }
    private async Task UnlockAppleTreeAsync()
    {
        await treeManager.UnlockTreeAsync(TreeListClass.Apple);
        await RefreshTreesAsync();
    }
    private async Task LockAppleTreeAsync()
    {
        await treeManager.LockTreeAsync(TreeListClass.Apple);
        await RefreshTreesAsync();
    }
    private async Task UnlockCowAsync()
    {
        await animalManager.UnlockAnimalAsync(AnimalListClass.Cow);
        await RefreshAnimalsAsync();
    }
    private async Task UnlockChickenAsync()
    {
        await animalManager.UnlockAnimalAsync(AnimalListClass.Chicken);
        await RefreshAnimalsAsync();
    }
    private async Task LockCowAsync()
    {
        await animalManager.LockAnimalAsync(AnimalListClass.Cow);
        await RefreshAnimalsAsync();
    }
    private async Task IncreaseCowOptionsAsync()
    {
        await animalManager.IncreaseAnimalOptionsAsync(AnimalListClass.Cow);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task DecreaseCowOptionsAsync()
    {
        await animalManager.DecreaseAnimalOptionsAsync(AnimalListClass.Cow);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task IncreaseChickenOptionsAsync()
    {
        await animalManager.IncreaseAnimalOptionsAsync(AnimalListClass.Chicken);
        toast.ShowSuccessToast("Updated Successfully");
    }
    private async Task DecreaseChickenOptionsAsync()
    {
        await animalManager.DecreaseAnimalOptionsAsync(AnimalListClass.Chicken);
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