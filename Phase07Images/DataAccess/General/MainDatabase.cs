namespace Phase07Images.DataAccess.General;
public static class MainDatabase
{
    public static string DatabasePath =>
        RepoDatabasePath.Get("FarmvilleV2.db");
    public const string DatabaseName = "Farmville";
    public static void Prep()
    {
        SqliteCreateDocumentDatabaseClass.RegisterCreatingDocumentDatabase();
        dd1.SQLiteConnector = new CustomSQLiteConnectionClass();
        bb1.SetupIConfiguration(); //hopefully good enough.
    }
}