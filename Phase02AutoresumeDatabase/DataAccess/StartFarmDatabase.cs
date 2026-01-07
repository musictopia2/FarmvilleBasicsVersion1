namespace Phase02AutoresumeDatabase.DataAccess;
public class StartFarmDatabase() : ListDataAccess<PlayerState>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "Start";
    //hopefully will work.
    //its okay if it wipes out the previos records for this project anyways.
    public async Task ImportAsync(BasicList<PlayerState> list)
    {
        await UpsertRecordsAsync(list);
    }

}