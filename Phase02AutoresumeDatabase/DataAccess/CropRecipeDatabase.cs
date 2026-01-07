namespace Phase02AutoresumeDatabase.DataAccess;
public class CropRecipeDatabase() : ListDataAccess<CropRecipeDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration
{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "CropRecipes";
    public async Task ImportAsync(BasicList<CropRecipeDocument> list)
    {
        await UpsertRecordsAsync(list);
    }
}