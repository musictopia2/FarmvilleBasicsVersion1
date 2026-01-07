namespace Phase17BeginningDataAbstractionsPart1.Services.Workshops;
public class WorkshopInstance
{
    public Guid Id { get; } = Guid.NewGuid();
    public int Capacity { get; set; } = 2; //for now, always 2.  later will rethink.
    public BasicList<CraftingJob> Queue { get; } = [];
    required
    public string BuildingName { get; init; }
    public bool CanAccept(WorkshopRecipe recipe) =>
        recipe.BuildingName == BuildingName &&
        Queue.Count(j => j.CompletedAt == null) < Capacity;
    public void Start()
    {
        var next = Queue.First(j => j.State == EnumWorkshopState.Waiting);
        next.Start();
    }
}