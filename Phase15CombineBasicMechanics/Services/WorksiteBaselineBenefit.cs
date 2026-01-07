namespace Phase15CombineBasicMechanics.Services;
public class WorksiteBaselineBenefit
{
    public EnumItemType Item { get; set; }
    public double Chance { get; set; } //this means each worker increases the chances by this amount.  if over 100, then becomes 100 obviously.
    public bool Guarantee { get; set; }
    public int Quantity { get; set; } = 1; //defaults to 1 because its usually 1.
}