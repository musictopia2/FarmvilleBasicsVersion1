namespace Phase08MultipleAnimals.Components.Custom;
public partial class CowComponent(GameState state)
{
    private EnumQuantity _selectedQuantity = EnumQuantity.Single; //i like defaulting to single if nothing else is selected.
    private System.Threading.Timer? _uiTimer;
    private BasicList<EnumQuantity> _quantities = [];
    protected override void OnInitialized()
    {
        _uiTimer = new System.Threading.Timer(_ => InvokeAsync(StateHasChanged), null, 0, 1000);
        _quantities = EnumQuantity.CompleteList;
    }

    private void SelectQuantity(EnumQuantity quantity)
    {
        _selectedQuantity = quantity;
    }

    private bool CanCollectMilk => state.MilkLeft > 0;
    private void ProduceMilk()
    {
        state.ProduceMilk(_selectedQuantity);
    }
    private void CollectMilk()
    {
        state.CollectMilk();
    }
    private string ProducingMilkText => $"Producing {state.MilkReturned(_selectedQuantity)} Milk";
    private string ReadyMilkText => $"Ready In {state.TimeLeftForCow}";
    private string FirstMilkDetails => $"Produces {state.MilkReturned(_selectedQuantity)} Milk";
    private string SecondMilkDetails => state.CowDuration(_selectedQuantity);

}