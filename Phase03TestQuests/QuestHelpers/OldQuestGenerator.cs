namespace Phase03TestQuests.QuestHelpers;
internal static class OldQuestGenerator
{
    public static BasicList<QuestRecipe> Generate(
        BasicList<QuestCandidate> candidates,
        int maxTotal)
    {
        BasicList<QuestRecipe> output = [];

        // 1) Coverage: every workshop at least once
        AddCoverageByProducer(output, candidates, EnumQuestSourceKind.Workshop, maxTotal);

        // 2) Coverage: every worksite at least once (any of the worksite categories)
        AddCoverageForWorksites(output, candidates, maxTotal);

        // 3) Fill remaining using caps
        FillWithCaps(output, candidates, maxTotal);

        // 4) Shuffle (optional)
        output.ShuffleList(); // if you have helper, otherwise implement Fisher–Yates

        return output;
    }

    private static void AddCoverageByProducer(
        BasicList<QuestRecipe> output,
        BasicList<QuestCandidate> candidates,
        EnumQuestSourceKind kind,
        int maxTotal)
    {
        var groups = candidates
            .Where(x => x.SourceKind == kind && x.ProducerId != "")
            .GroupBy(x => x.ProducerId)
            .ToList();

        foreach (var g in groups)
        {
            if (output.Count >= maxTotal)
            {
                return;
            }

            var pick = g.ToBasicList().GetRandomItem();
            TryAdd(output, pick, maxTotal);
        }
    }

    private static void AddCoverageForWorksites(
        BasicList<QuestRecipe> output,
        BasicList<QuestCandidate> candidates,
        int maxTotal)
    {
        var groups = candidates
            .Where(x => IsWorksite(x.SourceKind) && x.ProducerId != "")
            .GroupBy(x => x.ProducerId)
            .ToList();

        foreach (var g in groups)
        {
            if (output.Count >= maxTotal)
            {
                return;
            }

            // prefer non-rare for coverage if available
            var list = g.ToBasicList();
            var nonRare = list.Where(x => x.SourceKind != EnumQuestSourceKind.WorksiteRare).ToBasicList();
            var pick = nonRare.Count > 0 ? nonRare.GetRandomItem() : list.GetRandomItem();

            TryAdd(output, pick, maxTotal);
        }
    }

    private static void FillWithCaps(
        BasicList<QuestRecipe> output,
        BasicList<QuestCandidate> candidates,
        int maxTotal)
    {
        // Keep trying random picks until you reach maxTotal or you fail too many times.
        // (Failing happens if caps block everything remaining.)
        int attempts = 0;
        while (output.Count < maxTotal && attempts < 500)
        {
            attempts++;

            var pick = candidates.GetRandomItem();

            // Enforce per-kind caps
            int cap = QuestQuantityRules.MaxAllowedForKind(pick.SourceKind);
            int already = output.Count(x => x.SourceKind == pick.SourceKind);
            if (already >= cap)
            {
                continue;
            }

            // Optional: avoid exact duplicates (same producer + same item)
            if (output.Any(x => x.Item == pick.ItemKey && x.ProducerId == pick.ProducerId))
            {
                continue;
            }

            TryAdd(output, pick, maxTotal);
        }
    }

    private static void TryAdd(BasicList<QuestRecipe> output, QuestCandidate pick, int maxTotal)
    {
        if (output.Count >= maxTotal)
        {
            return;
        }

        // Per-kind cap check (important for coverage adds too)
        int cap = QuestQuantityRules.MaxAllowedForKind(pick.SourceKind);
        int already = output.Count(x => x.SourceKind == pick.SourceKind);
        if (already >= cap)
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