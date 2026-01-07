namespace Phase05UseRealDatabase.DataAccess.Animals;
public class AnimalInstanceDatabase(PlayerState player,
    IAnimalRegistry recipes
    ) : ListDataAccess<AnimalInstanceDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, IAnimalInstances

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "AnimalInstances";
    async Task<BasicList<AnimalDataModel>> IAnimalInstances.GetAnimalInstancesAsync()
    {
        var list = await recipes.GetAnimalsAsync();

        BasicList<AnimalDataModel> output = [];

        var others = await GetDocumentsAsync();
        int maxs = others.Single(x => x.Player.Equals(player)).HowMany;
        foreach (var item in list)
        {
            maxs.Times(x =>
            {
                output.Add(new AnimalDataModel()
                {
                    Name = item.Animal,
                    Unlocked = true,
                    UnlockedOptionCount = item.Options.Count
                });
            });
        }
        return output;
    }
}