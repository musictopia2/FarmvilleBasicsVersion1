namespace Phase01SimpleDatabase.DataAccess;
public class WorkshopRecipeDatabase() : ListDataAccess<WorkshopRecipeDocument>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "WorkshopRecipes";
    public async Task ImportAsync(BasicList<WorkshopRecipeDocument> list)
    {
        await UpsertRecordsAsync(list);
    }
}