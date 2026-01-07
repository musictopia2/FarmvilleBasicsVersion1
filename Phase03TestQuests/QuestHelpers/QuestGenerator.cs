namespace Phase03TestQuests.QuestHelpers;
internal static class QuestGenerator
{
    public static BasicList<QuestRecipe> GenerateUntilComplete(
        BasicList<QuestCandidate> candidates)
    {
        BasicList<QuestRecipe> output = [];

        // Determine which producers exist for coverage
        var allWorkshops = candidates
            .Where(x => x.SourceKind == EnumQuestSourceKind.Workshop && x.ProducerId != "")
            .Select(x => x.ProducerId!)
            .Distinct()
            .ToHashSet();

        var allWorksites = candidates
            .Where(x => IsWorksite(x.SourceKind) && x.ProducerId != "")
            .Select(x => x.ProducerId!)
            .Distinct()
            .ToHashSet();

        // Targets (minimums)
        const int minCrops = 3;
        const int minTrees = 1;
        const int minAnimals = 2;

        // Safety so we never hang if rules can’t be satisfied
        int attempts = 0;
        const int attemptLimit = 2000;

        while (attempts++ < attemptLimit)
        {
            if (IsDone(output, allWorkshops, allWorksites, minCrops, minTrees, minAnimals))
            {
                break;
            }

            // Choose what to add next based on what's missing
            var next = PickNextCandidate(candidates, output, allWorkshops, allWorksites, minCrops, minTrees, minAnimals);
            if (next is null)
            {
                break; // cannot satisfy more constraints (caps too tight or missing candidates)
            }

            TryAdd(output, next);
        }

        // Shuffle (optional)
        // output.ShuffleList();

        return output;
    }

    private static bool IsDone(
        BasicList<QuestRecipe> quests,
        HashSet<string> allWorkshops,
        HashSet<string> allWorksites,
        int minCrops,
        int minTrees,
        int minAnimals)
    {
        // Workshop coverage
        var touchedWorkshops = quests
            .Where(q => q.SourceKind == EnumQuestSourceKind.Workshop && q.ProducerId != "")
            .Select(q => q.ProducerId)
            .Distinct()
            .ToHashSet();

        if (touchedWorkshops.Count < allWorkshops.Count)
        {
            return false;
        }

        // Worksite coverage
        var touchedWorksites = quests
            .Where(q => IsWorksite(q.SourceKind) && q.ProducerId != "")
            .Select(q => q.ProducerId)
            .Distinct()
            .ToHashSet();

        if (touchedWorksites.Count < allWorksites.Count)
        {
            return false;
        }

        // Minimum category counts
        if (quests.Count(q => q.SourceKind == EnumQuestSourceKind.Crop) < minCrops)
        {
            return false;
        }

        if (quests.Count(q => q.SourceKind == EnumQuestSourceKind.Tree) < minTrees)
        {
            return false;
        }

        if (quests.Count(q => q.SourceKind == EnumQuestSourceKind.Animal) < minAnimals)
        {
            return false;
        }

        return true;
    }

    private static QuestCandidate? PickNextCandidate(
        BasicList<QuestCandidate> candidates,
        BasicList<QuestRecipe> current,
        HashSet<string> allWorkshops,
        HashSet<string> allWorksites,
        int minCrops,
        int minTrees,
        int minAnimals)
    {
        // 1) If a workshop not yet touched, pick from that workshop
        var touchedWorkshops = current
            .Where(q => q.SourceKind == EnumQuestSourceKind.Workshop && q.ProducerId != "")
            .Select(q => q.ProducerId)
            .Distinct()
            .ToHashSet();

        var missingWorkshop = allWorkshops.FirstOrDefault(w => touchedWorkshops.Contains(w) == false);
        if (missingWorkshop is not null)
        {
            var pool = candidates.Where(x => x.SourceKind == EnumQuestSourceKind.Workshop && x.ProducerId == missingWorkshop).ToBasicList();
            return pool.Count > 0 ? pool.GetRandomItem() : null;
        }

        // 2) If a worksite not yet touched, pick from that location (prefer non-rare)
        var touchedWorksites = current
            .Where(q => IsWorksite(q.SourceKind) && q.ProducerId != "")
            .Select(q => q.ProducerId)
            .Distinct()
            .ToHashSet();

        var missingWorksite = allWorksites.FirstOrDefault(w => touchedWorksites.Contains(w) == false);
        if (missingWorksite is not null)
        {
            var pool = candidates.Where(x => IsWorksite(x.SourceKind) && x.ProducerId == missingWorksite).ToBasicList();
            var nonRare = pool.Where(x => x.SourceKind != EnumQuestSourceKind.WorksiteRare).ToBasicList();
            if (nonRare.Count > 0)
            {
                return nonRare.GetRandomItem();
            }

            return pool.Count > 0 ? pool.GetRandomItem() : null;
        }

        // 3) Minimum counts for crops/trees/animals
        if (current.Count(q => q.SourceKind == EnumQuestSourceKind.Crop) < minCrops)
        {
            var pool = candidates.Where(x => x.SourceKind == EnumQuestSourceKind.Crop).ToBasicList();
            return pool.Count > 0 ? pool.GetRandomItem() : null;
        }

        if (current.Count(q => q.SourceKind == EnumQuestSourceKind.Tree) < minTrees)
        {
            var pool = candidates.Where(x => x.SourceKind == EnumQuestSourceKind.Tree).ToBasicList();
            return pool.Count > 0 ? pool.GetRandomItem() : null;
        }

        if (current.Count(q => q.SourceKind == EnumQuestSourceKind.Animal) < minAnimals)
        {
            var pool = candidates.Where(x => x.SourceKind == EnumQuestSourceKind.Animal).ToBasicList();
            return pool.Count > 0 ? pool.GetRandomItem() : null;
        }

        // 4) Otherwise, you can stop, or add optional extras:
        // For pre-test, I'd stop here.
        return null;
    }

    private static void TryAdd(BasicList<QuestRecipe> output, QuestCandidate pick)
    {
        // enforce caps
        int cap = QuestQuantityRules.MaxAllowedForKind(pick.SourceKind);
        int already = output.Count(q => q.SourceKind == pick.SourceKind);
        if (already >= cap)
        {
            return;
        }

        // optional: prevent duplicates by item+producer
        if (output.Any(q => q.Item == pick.ItemKey && q.ProducerId == (pick.ProducerId ?? "")))
        {
            return;
        }

        output.Add(new QuestRecipe
        {
            Item = pick.ItemKey,
            Required = QuestQuantityRules.GetRequired(pick.SourceKind),
            Completed = false,
            SourceKind = pick.SourceKind,
            ProducerId = pick.ProducerId ?? ""
        });
    }

    private static bool IsWorksite(EnumQuestSourceKind kind)
        => kind == EnumQuestSourceKind.WorksiteRare
        || kind == EnumQuestSourceKind.WorksiteCommon
        || kind == EnumQuestSourceKind.WorksiteGuaranteeOne
        || kind == EnumQuestSourceKind.WorksiteGuaranteeSeveral;
}
