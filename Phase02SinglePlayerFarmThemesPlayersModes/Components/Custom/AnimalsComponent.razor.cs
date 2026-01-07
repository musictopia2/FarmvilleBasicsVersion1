namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Custom;
public partial class AnimalsComponent(AnimalManager manager) : IDisposable
{
    private BasicList<AnimalView> _animals = [];
    override protected void OnInitialized()
    {
        manager.OnAnimalsUpdated += Refresh;
        UpdateAnimals();
    }
    private void UpdateAnimals()
    {
        _animals = manager.GetUnlockedAnimals;
    }
    private void Refresh()
    {
        UpdateAnimals();
        StateHasChanged();
    }
    public void Dispose()
    {
        manager.OnAnimalsUpdated -= Refresh;
        GC.SuppressFinalize(this);
    }
}