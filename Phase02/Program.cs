var inventory = new Inventory();
var windmill = new Windmill(inventory);

AnsiConsole.RunRepeatedly(async () =>
{
    //StyledTextBuilder builder = new();
    ComboMenu menu = new("Choose option");
    menu.Add("Craft Flour", CraftFlourAsync, windmill.CanProcess(EnumJobType.Flour))
        .Add("Craft Sugar", CraftSugarAsync, windmill.CanProcess(EnumJobType.Sugar))
        .Add("View Queue", ViewQueue);
    await AnsiConsole.ShowMenuAsync(menu);
    //builder.SetForeground(cc1.Yellow)
    //    .Append("Windmill Crafting");

    //AnsiConsole.MarkupLine(builder);



    //later worry about stylings.

    //options are:  craft flour, craft sugar, 




    //inventory.Print();
}, clearAfterEachRun: true);

Task CraftFlourAsync()
{
    windmill.Enqueue(EnumJobType.Flour);
    //Console.WriteLine("Beginnings of crafting flour");
    return Task.CompletedTask;
}
Task CraftSugarAsync()
{
    windmill.Enqueue(EnumJobType.Sugar);
    return Task.CompletedTask;
}
Task ViewQueue()
{
    windmill.PrintQueueSpectre();
    return Task.CompletedTask;
}
