namespace Phase01MultipleFarmStyles.Components.Custom;
public partial class CountryComponent(IGameTimer timer)
{
    private bool _loaded = false;
    protected override async Task OnInitializedAsync()
    {
        await timer.SetStyleContextAsync(FarmStyleList.Country);
        _loaded = true;
    }
}