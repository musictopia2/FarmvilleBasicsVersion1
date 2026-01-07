namespace Phase07Images.Components.Custom;

public partial class AnimalComponent
{

    [Parameter]
    [EditorRequired]
    public AnimalView Animal { get; set; } = default!;

    private int _selectedIndex;
    private bool _showOptions;
    private AnimalProductionOption? _selectedOption;

    protected override void OnParametersSet()
    {
        EnsureSelectedOption();
        base.OnParametersSet();
    }

    private void EnsureSelectedOption()
    {
        var options = AnimalManager.GetUnlockedProductionOptions(Animal);
        if (options.Count == 0)
        {
            _selectedOption = null;
            return;
        }

        if (_selectedIndex < 0 || _selectedIndex >= options.Count)
        {
            _selectedIndex = 0;
        }

        _selectedOption = options[_selectedIndex];
    }

    private EnumAnimalState State => AnimalManager.GetState(Animal);

    private bool CanOpenOptions => State == EnumAnimalState.None;
    private bool CanCollect => State == EnumAnimalState.Collecting && AnimalManager.Left(Animal) > 0;

    private bool _showProgress;


    private async void CardClickedAsync()
    {
        if (CanCollect)
        {
            await AnimalManager.CollectAsync(Animal);
            return;
        }

        if (CanOpenOptions)
        {
            _showOptions = true;
            return;
        }
        if (State == EnumAnimalState.Producing)
        {
            _showProgress = true;
            return;
        }
        //not sure yet.  once i get to it, figure out what to do.
    }


    private void ClosePopup() => _showOptions = false;

    // NEW: when an option is chosen, immediately start producing
    private void SelectOptionAndStart(int index)
    {
        _selectedIndex = index;
        EnsureSelectedOption();
        ClosePopup();

        if (State == EnumAnimalState.None)
        {
            AnimalManager.Produce(Animal, _selectedIndex);
        }
    }

    // --- Image path helpers (edit these to match your project) ---
    private static string Normalize(string text)
        => text.Replace(" ", "").Replace("-", "").Replace("_", "").ToLowerInvariant();

    private static string GetAnimalImage(string animalName)
        => $"/{Normalize(animalName)}.png";

    private static string GetItemImage(string itemName)
        => $"/{Normalize(itemName)}.png";


    private static string GetBackground(EnumAnimalState state) => state switch
    {
        EnumAnimalState.None => cc1.White.ToWebColor,
        EnumAnimalState.Producing => cc1.DarkGray.ToWebColor,
        EnumAnimalState.Collecting => cc1.Lime.ToWebColor,
        _ => cc1.DarkGray.ToWebColor
    };

}