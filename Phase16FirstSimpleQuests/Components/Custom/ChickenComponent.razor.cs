namespace Phase16FirstSimpleQuests.Components.Custom;
public partial class ChickenComponent(GameState state)
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


    private bool CanCollectEggs => state.EggsLeft > 0;
    private void ProduceEggs()
    {
        state?.ProduceEggs(_selectedQuantity);
    }
    private void CollectEggs()
    {
        state.CollectEggs();
    }
    private string ProducingEggsText => $"Producing {state.EggsInProgress} Eggs";
    private string ReadyEggsText => $"Ready In {state.TimeLeftForChicken}";
    private string FirstEggsDetails => $"Produces {state.EggsReturned(_selectedQuantity)} Eggs";
    private string SecondEggsDetails => state.ChickenDuration(_selectedQuantity);

}