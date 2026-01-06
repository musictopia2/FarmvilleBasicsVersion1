namespace Phase02;
public class Inventory
{
    public int Wheat { get; set; } = 13;
    public int Corn { get; set; } = 7;
    public int Flour { get; set; }
    public int Sugar { get; set; }

    public bool CanCraft(EnumJobType job) =>
        job switch
        {
            EnumJobType.Flour => Wheat >= 3,
            EnumJobType.Sugar => Corn >= 2,
            _ => false
        };

    public void Consume(EnumJobType job)
    {
        if (job == EnumJobType.Flour) Wheat -= 3;
        if (job == EnumJobType.Sugar) Corn -= 2;
    }

    public void Produce(EnumJobType job)
    {
        if (job == EnumJobType.Flour) Flour++;
        if (job == EnumJobType.Sugar) Sugar++;
    }
    private static void Print(string item, int value)
    {
        StyledTextBuilder builder = new();
        builder.Append(item)
            .Append(" ")
            .SetForeground(cc1.Lime)
            .Append(value.ToString());
        AnsiConsole.MarkupLine(builder);
    }
    public void Print()
    {
        Print("Wheat", Wheat);
        Print("Corn", Corn);
        Print("Flour", Flour);
        Print("Sugar", Sugar);



        //Console.WriteLine(
        //    $"Wheat:{Wheat} Corn:{Corn} Flour:{Flour} Sugar:{Sugar}");
    }
}