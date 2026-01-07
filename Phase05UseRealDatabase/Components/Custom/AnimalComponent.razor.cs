namespace Phase05UseRealDatabase.Components.Custom;
public partial class AnimalComponent
{
    [Parameter]
    [EditorRequired]
    public AnimalView Animal { get; set; }
    protected override void OnParametersSet()
    {
        ProcessOption();
        base.OnParametersSet();
    }
    private bool CanShowOptions => AnimalManager.GetState(Animal) == EnumAnimalState.None;

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
        _selectedOption = AnimalManager.GetUnlockedProductionOptions(Animal)[_selectedIndex];
    }
    private void SelectOption(int index)
    {
        _selectedIndex = index;
        ProcessOption();
        ClosePopup();
    }
    private bool CanCollect => AnimalManager.Left(Animal) > 0;
    private async Task Collect()
    {
        await AnimalManager.CollectAsync(Animal);
    }
    private void Produce()
    {
        AnimalManager.Produce(Animal, _selectedIndex);
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
    private string SecondDetails => AnimalManager.Duration(Animal, _selectedIndex);
    private string ProducingText => $"Producing {AnimalManager.InProgress(Animal)} {_selectedOption!.Output.Item}";
    private string ReadyText => $"Ready In {AnimalManager.TimeLeftForResult(Animal)}";
}