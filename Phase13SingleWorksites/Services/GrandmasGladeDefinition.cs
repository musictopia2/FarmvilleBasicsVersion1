namespace Phase13SingleWorksites.Services;
public static class GrandmasGladeDefinition
{
    public readonly static Dictionary<EnumItemType, WorksiteOutput> Output = [];
    static GrandmasGladeDefinition()
    {
        WorksiteOutput item = new()
        {
            CalculateAmount = ctx => 1,
            CalculateChance = ctx => 1.0,
        };
        Output[EnumItemType.Blackberries] = item;
        item = new()
        {
            CalculateAmount = ctx => 1,
            CalculateChance = (ctx) =>
            {
                if (ctx.Workers.Count == 1)
                {
                    return 0.75;
                }
                return 1.0; //for now.   may have the possibility of someone having reduced chances.
            }
        };
        Output[EnumItemType.Chives] = item;
        item = new()
        {
            CalculateAmount = ctx => 1,
            CalculateChance = (ctx) =>
            {
                if (ctx.Workers.Count == 1)
                {
                    return 0.03;
                }
                return 0.05;
            }
        };
        Output[EnumItemType.BarnNail] = item;
        item = new()
        {
            CalculateAmount = (ctx) =>
            {
                if (ctx.Workers.Contains(EnumWorkerType.Strawberries))
                {
                    return 1;
                }
                return 0;
            },
            CalculateChance = ctx => 1,
            Original = false
        };
        Output[EnumItemType.Strawberries] = item;

        item = new()
        {
            CalculateAmount = (ctx) =>
            {
                if (ctx.Workers.Contains(EnumWorkerType.GranillaBar))
                {
                    return 1;
                }
                return 0;
            },
            CalculateChance = (ctx) =>
            {
                if (ctx.Workers.Contains(EnumWorkerType.GranillaBar))
                {
                    return 0.60; //was 15 percent but changed to 60 percent so i can see everything is working for actually receiving sometimes.
                }
                return 0;
            },
            Original = false
        };
        Output[EnumItemType.GranillaBars] = item;
    }
    
}
