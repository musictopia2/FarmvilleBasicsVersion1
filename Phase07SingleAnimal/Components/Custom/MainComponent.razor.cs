namespace Phase07SingleAnimal.Components.Custom;
public partial class MainComponent(GameState state)
{
    private System.Threading.Timer? _uiTimer;
    private EnumQuantity _selectedQuantity = EnumQuantity.Single; //i like defaulting to single if nothing else is selected.
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
    private string ProducingText => $"Producing {state.MilkReturned(_selectedQuantity)} Milk";
    private string ReadyText => $"Ready In {state.TimeLeftForCow}";
    private string FirstDetails => $"Produces {state.MilkReturned(_selectedQuantity)} Milk";
    private string SecondDetails => state.CowDuration(_selectedQuantity);
}