namespace Phase07Images.Components.Custom;
public partial class AnimalChoiceModal
{
    [Parameter]
    [EditorRequired]
    public AnimalView Animal { get; set; } = default!;

    [Parameter]
    public EventCallback<int> OnOptionChosen { get; set; }

    private BasicList<AnimalProductionOption> _productionOptions = [];

    protected override void OnParametersSet()
    {
        _productionOptions = AnimalManager.GetUnlockedProductionOptions(Animal);
    }

    private void OptionSelected(AnimalProductionOption option)
    {
        int index = _productionOptions.IndexOf(option);
        OnOptionChosen.InvokeAsync(index);
    }

    // --- Image path helper (edit to match your project) ---
    private static string Normalize(string text)
        => text.Replace(" ", "").Replace("-", "").Replace("_", "").ToLowerInvariant();

    private static string GetItemImage(string itemName)
        => $"/{Normalize(itemName)}.png";


    private string GetDurationText(AnimalProductionOption option)
    {
        
        int index = _productionOptions.IndexOf(option);
        return AnimalManager.Duration(Animal, index); // <-- rename to your real method
    }

}