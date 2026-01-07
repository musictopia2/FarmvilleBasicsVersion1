namespace Phase16FirstSimpleQuests.Services;
public class AnimalRecipe(Dictionary<EnumQuantity, AnimalProductionOption> options)
{
    public EnumItemType Output { get; init; }
    public EnumItemType Required { get; init; }
    public EnumAnimalType Animal { get; init; }
    public AnimalProductionOption GetProduction(EnumQuantity quantity) => options[quantity];
}