namespace Phase03TestQuests.ImportClasses;
public static class ImportQuestInstancesClass
{
    public static async Task ImportQuestsAsync()
    {
        QuestInstanceDatabase db = new();
        BasicList<QuestDocument> list = [];
        list.Add(await GetCountryQuestsAsync());
        list.Add(await GetTropicalQuestsAsync());
        await db.ImportAsync(list);
    }

    private static PlayerState GetPlayer(string theme)
    {
        return new()
        {
            FarmTheme = theme,
            PlayerName = PlayerList.Player1,
            SessionMode = SessionModeList.SimpleTesting
        };
    }

    private static async Task<QuestDocument> GetCountryQuestsAsync()
    {
        PlayerState player = GetPlayer(FarmThemeList.Country);

        BasicList<QuestCandidate> possibleList = await CompletePossibleCombosClass.GetCompletePossibilitiesAsync(player);

        BasicList<QuestRecipe> list = QuestGenerator.GenerateUntilComplete(possibleList);
        Console.WriteLine(list.Count);
        return new()
        {
            Player = player,
            Quests = list
        };

    }
    private static async Task<QuestDocument> GetTropicalQuestsAsync()
    {
        PlayerState player = GetPlayer(FarmThemeList.Tropical);
        BasicList<QuestCandidate> possibleList = await CompletePossibleCombosClass.GetCompletePossibilitiesAsync(player);

        BasicList<QuestRecipe> list = QuestGenerator.GenerateUntilComplete(possibleList);
        Console.WriteLine(list.Count);
        return new()
        {
            Player = player,
            Quests = list
        };
    }

}
