namespace Phase03TestQuests.QuestHelpers;
internal static class QuestQuantityRules
{
    private readonly static IRandomNumberList _rs;
    static QuestQuantityRules()
    {
        _rs = rs1.GetRandomGenerator();
    }
    public static int GetRequired(EnumQuestSourceKind kind)
    {
        if (kind == EnumQuestSourceKind.Tree)
        {
            return _rs.GetRandomNumber(15, 8);
        }
        if (kind == EnumQuestSourceKind.Crop)
        {
            return _rs.GetRandomNumber(35, 18);
        }
        if (kind == EnumQuestSourceKind.Animal)
        {
            return _rs.GetRandomNumber(12, 6);
        }
        if (kind == EnumQuestSourceKind.Workshop)
        {
            return _rs.GetRandomNumber(8, 4);
        }
        if (kind == EnumQuestSourceKind.WorksiteRare)
        {
            return _rs.GetRandomNumber(2, 1);
        }
        if (kind == EnumQuestSourceKind.WorksiteCommon)
        {
            return _rs.GetRandomNumber(4, 2);
        }
        if (kind == EnumQuestSourceKind.WorksiteGuaranteeSeveral)
        {
            return _rs.GetRandomNumber(15, 10);
        }
        if (kind == EnumQuestSourceKind.WorksiteGuaranteeOne)
        {
            return _rs.GetRandomNumber(6, 4);
        }
        throw new CustomBasicException("Nothing found");
    }

    public static int MaxAllowedForKind(EnumQuestSourceKind kind)
    {
        // how many quests of each worksite category may appear in the whole run
        return kind switch
        {
            EnumQuestSourceKind.WorksiteRare => 1,
            EnumQuestSourceKind.WorksiteCommon => 2,
            EnumQuestSourceKind.Tree => 1, //only one needed for trees
            EnumQuestSourceKind.Animal => 2,
            EnumQuestSourceKind.Crop => 3,
            _ => int.MaxValue
        };
    }

}
