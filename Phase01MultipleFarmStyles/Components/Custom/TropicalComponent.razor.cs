namespace Phase01MultipleFarmStyles.Components.Custom;
public partial class TropicalComponent(IGameTimer timer)
{
    private bool _loaded = false;
    protected override async Task OnInitializedAsync()
    {
        await timer.SetStyleContextAsync(FarmStyleList.Tropical);
        _loaded = true;
    }
}