using Microsoft.Win32;
namespace CardAccess.Settings;

/// <summary>
/// Generic settings routines used by several modules.
/// </summary>
public class CommonSettings
{
    /// <summary>
    /// Determines if the utilities password dialog box should be displayed.
    /// </summary>
    /// <returns></returns>
    public static bool ShowPasswordDialog() =>
        ReadRegistry(Registry.CurrentUser, "Software\\Continental Access\\DBUtils", "checked", 1);
    public static bool HidePasswordDialog(bool bvalue)
    {
        try
        {
            if (bvalue)
                WriteToRegistry(Registry.CurrentUser, "Software\\Continental Access\\DBUtils", "checked", 1);
            else
                WriteToRegistry(Registry.CurrentUser, "Software\\Continental Access\\DBUtils", "checked", 0);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool WriteIsServer(bool bvalue)
    {
        try
        {
            if (bvalue)
            {
                WriteToRegistry(Registry.CurrentUser, "Software\\Continental Access\\Server", "checked", 1);
            }
            else
            {
                WriteToRegistry(Registry.CurrentUser, "Software\\Continental Access\\Server", "checked", 0);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool CheckServer() =>
        ReadRegistry(Registry.CurrentUser, "Software\\Continental Access\\Server", "checked", 1);

#pragma warning disable IDE0060 // Remove unused parameter
    private static bool ReadRegistry(RegistryKey parentKey, string subKey, string valueName, object value)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        bool retVal = false;
        try
        {
            RegistryKey key = parentKey.OpenSubKey(subKey, true);
            if (key == null)
            {
            }
            else
            {
                value = key.GetValue(valueName);
                if (Convert.ToInt32(value) == 1)
                {
                    retVal = true;
                }
            }
            return retVal;
        }
        catch (Exception)
        {
            return retVal;
        }
    }

    public static string ReadGuiRegistry(string valueName)
    {
        string retVal = "";
        try
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Continental Access\\CardAccess\\1.0\\GUI", true);
            if (key == null)
            {
            }
            else
            {
                object value = key.GetValue(valueName);
                retVal = value.ToString();
            }
            return retVal;
        }
        catch (Exception)
        {
            return retVal;
        }
    }

    public static bool WriteGuiRegistry(string valueName, object value)
    {
        RegistryKey key;
        bool retVal = false;
        string subKey = "Software\\Continental Access\\CardAccess\\1.0\\GUI";
        try
        {
            key = Registry.CurrentUser.OpenSubKey(subKey, true);
            key ??= Registry.CurrentUser.CreateSubKey(subKey);
            key.SetValue(valueName, value);
            retVal = true;
            return retVal;
        }
        catch (Exception)
        {

            return retVal;
        }
    }

    public static void WriteToRegistry(object value) =>
        WriteToRegistry(Registry.CurrentUser, "Software\\Continental Access\\DBUtils", "checked", value);



    public static bool WriteToRegistry(RegistryKey parentKey, string subKey, string valueName, object value)
    {
        RegistryKey key;
        bool retVal = false;
        try
        {
            key = parentKey.OpenSubKey(subKey, true);
            key ??= parentKey.CreateSubKey(subKey);
            key.SetValue(valueName, value);
            retVal = true;
            return retVal;
        }
        catch (Exception)
        {

            return retVal;
        }
    }

}

public static class ODBCManager
{
    private const string ODBC_INI_REG_PATH = "SOFTWARE\\ODBC\\ODBC.INI\\";
    private const string ODBCINST_INI_REG_PATH = "SOFTWARE\\ODBC\\ODBCINST.INI\\";

    /// <summary>
    /// Creates a new DSN entry with the specified values. If the DSN exists, the values are updated.
    /// </summary>
    /// <param name="dsnName">Name of the DSN for use by client applications</param>
    /// <param name="description">Description of the DSN that appears in the ODBC control panel applet</param>
    /// <param name="server">Network name or IP address of database server</param>
    /// <param name="driverName">Name of the driver to use</param>
    /// <param name="trustedConnection">True to use NT authentication, false to require applications to supply username/password in the connection string</param>
    /// <param name="database">Name of the datbase to connect to</param>
    public static void CreateDSN(string dsnName, string description, string server, string driverName, bool trustedConnection, string database, string uid)
    {
        // Lookup driver path from driver name
        var driverKey = Registry.LocalMachine.CreateSubKey(ODBCINST_INI_REG_PATH + driverName) ?? throw new Exception(string.Format("ODBC Registry key for driver '{0}' does not exist", driverName));
        string driverPath = driverKey.GetValue("Driver").ToString();

        // Add value to odbc data sources
        var datasourcesKey = Registry.LocalMachine.CreateSubKey(ODBC_INI_REG_PATH + "ODBC Data Sources") ?? throw new Exception("ODBC Registry key for datasources does not exist");
        datasourcesKey.SetValue(dsnName, driverName);

        // Create new key in odbc.ini with dsn name and add values
        var dsnKey = Registry.LocalMachine.CreateSubKey(ODBC_INI_REG_PATH + dsnName) ??
            throw new Exception("ODBC Registry key for DSN was not created");
        dsnKey.SetValue("Database", database);
        dsnKey.SetValue("Description", description);
        dsnKey.SetValue("Driver", driverPath);
        dsnKey.SetValue("LastUser", uid);
        dsnKey.SetValue("Server", server);
        dsnKey.SetValue("Database", database);
        dsnKey.SetValue("Trusted_Connection", trustedConnection ? "Yes" : "No");
    }

    /// <summary>
    /// Removes a DSN entry
    /// </summary>
    /// <param name="dsnName">Name of the DSN to remove.</param>
    public static void RemoveDSN(string dsnName)
    {
        // Remove DSN key
        Registry.LocalMachine.DeleteSubKeyTree(ODBC_INI_REG_PATH + dsnName);

        // Remove DSN name from values list in ODBC Data Sources key
        var datasourcesKey = Registry.LocalMachine.CreateSubKey(ODBC_INI_REG_PATH + "ODBC Data Sources") ?? throw new Exception("ODBC Registry key for datasources does not exist");
        datasourcesKey.DeleteValue(dsnName);
    }

    ///<summary>
    /// Checks the registry to see if a DSN exists with the specified name
    ///</summary>
    ///<param name="dsnName"></param>
    ///<returns></returns>

    public static bool DSNExists(string dsnName)
    {
        var sourcesKey = Registry.LocalMachine.CreateSubKey(ODBC_INI_REG_PATH + "ODBC Data Sources");
        return sourcesKey == null
            ? throw new Exception("ODBC Registry key for sources does not exist")
            : sourcesKey.GetValue(dsnName) != null;
    }

    ///<summary>
    /// Returns an array of driver names installed on the system
    ///</summary>
    ///<returns></returns>
    public static string[] GetInstalledDrivers()
    {
        var driversKey = Registry.LocalMachine.CreateSubKey(ODBCINST_INI_REG_PATH + "ODBC Drivers") ?? throw new Exception("ODBC Registry key for drivers does not exist");
        var driverNames = driversKey.GetValueNames();

        var ret = new List<string>();

        foreach (var driverName in driverNames)
        {
            if (driverName != "(Default)")
            {
                ret.Add(driverName);
            }
        }
        return [.. ret];
    }
}
