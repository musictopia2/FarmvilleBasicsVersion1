namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Custom;

public partial class AnimalComponent(AnimalManager manager)
{

    [Parameter]
    [EditorRequired]
    public AnimalView Animal { get; set; }
    protected override void OnParametersSet()
    {
        ProcessOption();
        base.OnParametersSet();
    }
    private bool CanShowOptions => manager.GetState(Animal) == EnumAnimalState.None;

    private int _selectedIndex = 0;

    private bool _showOptions = false;

    private AnimalProductionOption? _selectedOption;

    //private AnimalProductionOption GetOption => manager.GetProductionOptions(Animal)[_selectedIndex];

    private void ChooseOption()
    {
        _showOptions = true;
    }
    private void ClosePopup()
    {
        _showOptions = false;
    }
    private void ProcessOption()
    {
        _selectedOption = manager.GetUnlockedProductionOptions(Animal)[_selectedIndex];
    }
    private void SelectOption(int index)
    {
        _selectedIndex = index;
        ProcessOption();
        ClosePopup();
    }
    private bool CanCollect => manager.Left(Animal) > 0;
    private void Collect()
    {
        manager.CollectSingle(Animal);
    }
    private void Produce()
    {
        manager.Produce(Animal, _selectedIndex);
    }
    private string GetOptionChosenText
    {
        get
        {
            if (_selectedOption is null)
            {
                return "No Option Chosen";
            }
            return $"Produces {_selectedOption.Output.Item} Giving {_selectedOption.Output.Amount} Required ({_selectedOption.Input} {_selectedOption.Required})";
        }
    }
    private string SecondDetails => manager.Duration(Animal, _selectedIndex);
    private string ProducingText => $"Producing {manager.InProgress(Animal)} {_selectedOption!.Output.Item}";
    private string ReadyText => $"Ready In {manager.TimeLeftForResult(Animal)}";
}