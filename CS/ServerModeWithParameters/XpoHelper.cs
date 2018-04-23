using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

/// <summary>
/// Summary description for XpoHelper
/// </summary>
public static class XpoHelper {
    public static Session GetNewSession() {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork() {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object lockObject = new object();

    static IDataLayer fDataLayer;
    static IDataLayer DataLayer {
        get {
            if(fDataLayer == null) {
                lock(lockObject) {
                    fDataLayer = GetDataLayer();
                }
            }
            return fDataLayer;
        }
    }

    private static IDataLayer GetDataLayer() {
        // set XpoDefault.Session to null to prevent accidental use of XPO default session
        XpoDefault.Session = null;

        string conn = MSSqlConnectionProvider.GetConnectionString("(local)", "AdventureWorks");
        XPDictionary dict = new ReflectionDictionary();
        IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
        dict.GetDataStoreSchema(typeof(AdventureWorks.Customer).Assembly);
        IDataLayer dl = new ThreadSafeDataLayer(dict, store);

        return dl;
    }
}
