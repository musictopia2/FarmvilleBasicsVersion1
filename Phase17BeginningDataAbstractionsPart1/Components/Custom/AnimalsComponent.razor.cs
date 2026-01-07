namespace Phase17BeginningDataAbstractionsPart1.Components.Custom;
public partial class AnimalsComponent(AnimalManager manager)
{
    private BasicList<AnimalSummary> _animals = [];
    override protected void OnInitialized()
    {
        _animals = manager.GetAllAnimals;
    }
}