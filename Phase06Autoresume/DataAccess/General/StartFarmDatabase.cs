namespace Phase06Autoresume.DataAccess.General;
public class StartFarmDatabase() : ListDataAccess<PlayerState>
    (DatabaseName, CollectionName, mm1.DatabasePath),
    ISqlDocumentConfiguration, IStartFarmRegistry

{
    public static string DatabaseName => mm1.DatabaseName;
    public static string CollectionName => "Start";
    Task<BasicList<PlayerState>> IStartFarmRegistry.GetFarmsAsync()
    {
        return GetDocumentsAsync();
    }
}