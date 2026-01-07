namespace Phase07Images.DataAccess.Crops;
public class CropRecipeDatabase(PlayerState player) : ListDataAccess<CropRecipeDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, ICropRegistry
{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "CropRecipes";

    async Task<BasicList<CropRecipe>> ICropRegistry.GetCropsAsync()
    {
        BasicList<CropRecipeDocument> list = await GetDocumentsAsync();
        BasicList<CropRecipe> output = [];
        list.ForConditionalItems(x => x.Mode == player.SessionMode && x.Theme == player.FarmTheme, old =>
        {
            output.Add(new()
            {
                Duration = old.Duration,
                Item = old.Item
            });
        });
        return output;
    }
}