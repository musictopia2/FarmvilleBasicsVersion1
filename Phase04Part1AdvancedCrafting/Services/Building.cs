namespace Phase04Part1AdvancedCrafting.Services;
public abstract class Building
{
    public Guid Id { get; } = Guid.NewGuid();
    public int Capacity { get; set; } = 2; //for now, always 2.  later will rethink.
    public BasicList<CraftingJob> Queue { get; } = [];
    public abstract EnumBuildingCategory Category { get; }
    public bool CanAccept(RecipeModel recipe) =>
        recipe.Building == Category &&
        Queue.Count(j => j.CompletedAt == null) < Capacity;

    
    public void Start()
    {
        var next = Queue.First(j => j.State == EnumJobState.Waiting);
        next.Start();
    }

}