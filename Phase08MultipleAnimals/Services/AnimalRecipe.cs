namespace Phase08MultipleAnimals.Services;
public class AnimalRecipe(Dictionary<EnumQuantity, AnimalProductionOption> options)
{
    public EnumItemType Output { get; init; }
    //public BasicList<AnimalProductionOption> Options { get; } = options;
    public EnumItemType Required { get; init; }
    public EnumAnimalType Animal { get; init; }

    public AnimalProductionOption GetProduction(EnumQuantity quantity) => options[quantity];

}