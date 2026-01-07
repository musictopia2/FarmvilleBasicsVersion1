namespace Phase03TestQuests.QuestHelpers;
internal static class CompletePossibleCombosClass
{
    public static async Task<BasicList<QuestCandidate>> GetCompletePossibilitiesAsync(PlayerState player)
    {
        
        BasicList<QuestCandidate> output = [];
        output.AddRange(await GetTreesAsync(player));
        output.AddRange(await GetCropsAsync(player));
        output.AddRange(await GetAnimalsAsync(player));
        output.AddRange(await GetWorkshopsAsync(player));
        output.AddRange(await GetWorksitesAsync(player));
        return output;
    }
    private static async Task<BasicList<QuestCandidate>> GetTreesAsync(PlayerState player)
    {
        TreeRecipeDatabase db = new();
        BasicList<TreeRecipeDocument> recipes = await db.GetRecipesAsync();
        BasicList<QuestCandidate> output = [];
        recipes.ForConditionalItems(x => x.Theme == player.FarmTheme && x.Mode == player.SessionMode, recipe =>
        {
            QuestCandidate candidate = new()
            {
                ItemKey = recipe.Item,
                ProducerId = recipe.TreeName,
                SourceKind = EnumQuestSourceKind.Tree
            };
            output.Add(candidate);
        });
        return output;
    }

    private static async Task<BasicList<QuestCandidate>> GetCropsAsync(PlayerState player)
    {
        CropRecipeDatabase db = new();
        BasicList<CropRecipeDocument> recipes = await db.GetRecipesAsync();
        BasicList<QuestCandidate> output = [];
        recipes.ForConditionalItems(x => x.Theme == player.FarmTheme && x.Mode == player.SessionMode, recipe =>
        {
            QuestCandidate candidate = new()
            {
                ItemKey = recipe.Item,
                ProducerId = recipe.Item,
                SourceKind = EnumQuestSourceKind.Crop
            };
            output.Add(candidate);
        });
        return output;
    }

    private static async Task<BasicList<QuestCandidate>> GetAnimalsAsync(PlayerState player)
    {
        AnimalRecipeDatabase db = new();
        BasicList<AnimalRecipeDocument> recipes = await db.GetRecipesAsync();
        BasicList<QuestCandidate> output = [];
        recipes.ForConditionalItems(x => x.Theme == player.FarmTheme && x.Mode == player.SessionMode, recipe =>
        {
            QuestCandidate candidate = new()
            {
                ItemKey = recipe.Options.First().Output.Item,
                SourceKind = EnumQuestSourceKind.Animal,
                ProducerId = recipe.Animal
            };
            output.Add(candidate);
        });
        return output;
    }

    private static async Task<BasicList<QuestCandidate>> GetWorkshopsAsync(PlayerState player)
    {
        WorkshopRecipeDatabase db = new();
        BasicList<WorkshopRecipeDocument> recipes = await db.GetRecipesAsync();
        BasicList<QuestCandidate> output = [];
        recipes.ForConditionalItems(x => x.Theme == player.FarmTheme && x.Mode == player.SessionMode, recipe =>
        {
            QuestCandidate candidate = new()
            {
                ItemKey = recipe.Output.Item,
                SourceKind = EnumQuestSourceKind.Workshop,
                ProducerId = recipe.BuildingName
            };
            output.Add(candidate);
        });
        return output;
    }
    private static async Task<BasicList<QuestCandidate>> GetWorksitesAsync(PlayerState player)
    {
        WorksiteRecipeDatabase db = new();
        BasicList<WorksiteRecipeDocument> recipes = await db.GetRecipesAsync();
        BasicList<QuestCandidate> output = [];
        recipes.ForConditionalItems(x => x.Theme == player.FarmTheme && x.Mode == player.SessionMode, recipe =>
        {
            recipe.BaselineBenefits.ForConditionalItems(x => x.Optional == false, benefit =>
            {
                EnumQuestSourceKind category;

                if (benefit.Guarantee && benefit.EachWorkerGivesOne)
                {
                    category = EnumQuestSourceKind.WorksiteGuaranteeSeveral;
                }
                else if (benefit.Guarantee && benefit.Chance > .5)
                {
                    category = EnumQuestSourceKind.WorksiteGuaranteeOne; //since you can use at least 2 workers, you can send 2 and guarantee this.
                }
                else if (benefit.Chance > .25)
                {
                    category = EnumQuestSourceKind.WorksiteCommon;
                }
                else
                {
                    category = EnumQuestSourceKind.WorksiteRare;
                }
                QuestCandidate candidate = new()
                {
                    ItemKey = benefit.Item,
                    SourceKind = category,
                    ProducerId = recipe.Location
                };
                output.Add(candidate);
            });
        });
        return output;
    }
}