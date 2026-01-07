namespace Phase13SingleWorksites.Services;
public class WorksiteOutput
{
    //probably needs to be a dictionary.  no duplicates for Item.

    //public EnumItemType Item { get; set; }
    //public int Amount { get; init; } = 1;
    //public double Chance { get; init; } = 1.0; // 1.0 = guaranteed

    public Func<WorksiteJobContext, double>? CalculateChance { get; init; }
    public Func<WorksiteJobContext, int>? CalculateAmount { get; init; }
    public bool Original { get; set; } = true; //most are original.   some are extra only with some workers.


    //public Func<WorksiteJobContext, bool>? Condition { get; init; }
}