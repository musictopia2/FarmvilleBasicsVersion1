namespace Phase02SinglePlayerFarmThemesPlayersModes.Components.Custom;
public partial class AnimalChoiceModal(AnimalManager manager)
{
    [Parameter]
    [EditorRequired]
    public AnimalView Animal { get; set; }
    [Parameter]
    public EventCallback<int> OnOptionChosen { get; set; }
    private BasicList<AnimalProductionOption> _productionOptions = [];
    protected override void OnParametersSet()
    {
        _productionOptions = manager.GetUnlockedProductionOptions(Animal);
    }
    private static string GetButtonText(AnimalProductionOption option)
    {
        //previously Single (3 Wheat)

        //eventually can have images.

        return $"Get {option.Output.Amount} {option.Output.Item} Requires ({option.Input} {option.Required})";
    }
    private void OptionSelected(AnimalProductionOption option)
    {
        int index = _productionOptions.IndexOf(option);
        OnOptionChosen.InvokeAsync(index);
    }
}