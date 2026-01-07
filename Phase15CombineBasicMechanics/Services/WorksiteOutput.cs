namespace Phase15CombineBasicMechanics.Services;
public class WorksiteOutput
{
    //probably needs to be a dictionary.  no duplicates for Item.

    //public EnumItemType Item { get; set; }
    //public int Amount { get; init; } = 1;
    //public double Chance { get; init; } = 1.0; // 1.0 = guaranteed

    //public Func<WorksiteJobContext, double>? CalculateChance { get; init; }
    //public Func<WorksiteJobContext, int>? CalculateAmount { get; init; }
    public bool Original { get; set; } = true; //most are original.   some are extra only with some workers.

    public int Amount { get; set; }
    public double Chances { get; set; }
    public EnumItemType Item { get; set; } //okay to duplicate it here i think (if i am wrong, rethink).



    //public Func<WorksiteJobContext, bool>? Condition { get; init; }
}