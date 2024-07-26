using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

namespace CardAccess.Settings
{
    /// <summary>
    /// Company Object Class for Maintaining a list of companies for monitoring different systems fro the same gui
    /// used by mbl and gui
    /// </summary>
    [Serializable]
    public class CompanyObj
    {
        /// <summary>
        /// Unique number for each company
        /// </summary>
        private int companyNumber;
        public int CompanyNumber { get { return companyNumber; } set { companyNumber = value; } }

        /// <summary>
        /// Name of company for selection
        /// </summary>
        private string companyName;
        public string CompanyName { get { return companyName; } set { companyName = value; } }

        /// <summary>
        /// List of DB settings for name and server
        /// </summary>
        private DatabaseCollection databaseList = new DatabaseCollection();
        public DatabaseCollection DatabaseList { get { return databaseList; } set { databaseList = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pCompanyName"></param>
        /// <param name="pCoNum"></param>
        public CompanyObj(string pCompanyName, int pCoNum)
        {
            CompanyName = pCompanyName;
            CompanyNumber = pCoNum;
        }


    }
    /// <summary>
    /// DB Settings Object Class for Maintaining a list of companies for monitoring different systems fro the same gui
    /// used by mbl and gui
    /// </summary>
    [Serializable]
    public class DatabaseSettingsObj
    {
        public int ConfigSystemSettingId { get; set; }

        /// <summary>
        /// Server name
        /// </summary>
        private string server;
        public string Server { get { return server; } set { server = value; } }

        /// <summary>
        /// DB Name
        /// </summary>
        private string database;
        public string Database { get { return database; } set { database = value; } }

        /// <summary>
        /// User ID
        /// </summary>
        private string user;
        public string User { get { return user; } set { user = value; } }

        /// <summary>
        /// Password
        /// </summary>
        private string password;
        public string Password { get { return password; } set { password = value; } }

        public string ArchiveServer { get; set; }
        public string ArchiveDatabase { get; set; }

        public override string ToString()
        {
            return $"ConfigSystemSettingId: {ConfigSystemSettingId}, Server: {Server}, Database: {Database}, User: {User}, Password: {Password}";
        }
    }

    /// <summary>
    /// DB Object Class for Maintaining a list of companies for monitoring different systems fro the same gui
    /// used by mbl and gui
    /// </summary>
    [Serializable]
    public class DatabaseObj
    {
        /// <summary>
        /// Name of DB
        /// </summary>
        private string databaseName;
        public string DatabaseName { get { return databaseName; } set { databaseName = value; } }

        /// <summary>
        /// Settings for DB
        /// </summary>
        private DatabaseSettingsObj settings = new DatabaseSettingsObj();
        public DatabaseSettingsObj Settings { get { return settings; } set { settings = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDatabaseName"></param>
        /// <param name="pServer"></param>
        /// <param name="pDatabase"></param>
        /// <param name="pUser"></param>
        /// <param name="pPassword"></param>
        public DatabaseObj(
              string pDatabaseName
            , string pServer
            , string pDatabase
            , string pUser
            , string pPassword)
        {
            DatabaseName = pDatabaseName;
            Settings.Server = pServer;
            Settings.Database = pDatabase;
            Settings.User = pUser;
            Settings.Password = pPassword;
        }
    }
    /// <summary>
    /// DB List Object Class for Maintaining a list of companies for monitoring different systems fro the same gui
    /// used by mbl and gui
    /// </summary>
    [Serializable]
    public class DatabaseCollection : Collection<DatabaseObj>
    {
        /// <summary>
        /// Adds db to collection
        /// </summary>
        /// <param name="pDatabaseName"></param>
        /// <param name="pServer"></param>
        /// <param name="pDatabase"></param>
        /// <param name="pUser"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public DatabaseObj AddDatabase(string pDatabaseName
            , string pServer
            , string pDatabase
            , string pUser
            , string pPassword
            )
        {
            DatabaseObj obj = new DatabaseObj(pDatabaseName, pServer, pDatabase, pUser, pPassword);
            this.Add(obj);
            return obj;
        }
        /// <summary>
        /// returns db object from collection
        /// </summary>
        /// <param name="pDatabaseName"></param>
        /// <returns></returns>
        public DatabaseObj Item(string pDatabaseName)
        {
            foreach (DatabaseObj obj in this)
            {
                if (obj.DatabaseName.Equals(pDatabaseName))
                    return obj;
            }
            return null;
        }
    }
    /// <summary>
    /// Company List Object Class for Maintaining a list of companies for monitoring different systems fro the same gui
    /// used by mbl and gui
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class CompanyCollection : Collection<CompanyObj>
    {
        /// <summary>
        /// Enum for DB Type
        /// </summary>
        public enum DataBaseType { LiveConfig, LiveEvents, ComDB }

        /// <summary>
        /// Adds a company to collection
        /// </summary>
        /// <param name="pCompanyName"></param>
        /// <returns></returns>
        public CompanyObj AddCompany(string pCompanyName)
        {
            CompanyObj obj = new CompanyObj(pCompanyName, this.Count + 1);
            this.Add(obj);
            return obj;
        }
        /// <summary>
        /// Adds a company to collection
        /// </summary>
        /// <param name="pCompanyName"></param>
        /// <param name="pCompanyNumber"></param>
        /// <returns></returns>
        public CompanyObj AddCompany(string pCompanyName, int pCompanyNumber)
        {
            CompanyObj obj = new CompanyObj(pCompanyName, pCompanyNumber);
            this.Add(obj);
            return obj;
        }

        /// <summary>
        /// Adds a company to collection
        /// </summary>
        /// <param name="pCompanyName"></param>
        /// <returns></returns>
        public CompanyObj AddNewCompany(string pCompanyName)
        {
            int nextNumber = GetNextCompanyNumber();
            return AddCompany(pCompanyName, nextNumber);
        }

        /// <summary>
        /// returns company from collection
        /// </summary>
        /// <param name="pCompanyName"></param>
        /// <returns></returns>
        public CompanyObj Item(string pCompanyName)
        {
            foreach (CompanyObj obj in this)
            {
                if (obj.CompanyName.Equals(pCompanyName))
                    return obj;
            }
            return null;
        }
        /// <summary>
        /// returns company from collection by number
        /// </summary>
        /// <param name="pCompanyNumber"></param>
        /// <returns></returns>
        public CompanyObj ItemNo(int pCompanyNumber)
        {
            foreach (CompanyObj obj in this)
            {
                if (obj.CompanyNumber.Equals(pCompanyNumber))
                    return obj;
            }
            return null;
        }


        /// <summary>
        /// returns next available company number
        /// </summary>
        /// <returns></returns>
        private int GetNextCompanyNumber()
        {
            int nextNumber = 0;
            CompanyObj co = null;
            do
            {
                nextNumber++;
                co = ItemNo(nextNumber);
            }
            while (co != null);
            return nextNumber;
        }

        /// <summary>
        /// returns DB Settings for a company
        /// </summary>
        /// <param name="pCompanyNo"></param>
        /// <param name="pDbt"></param>
        /// <returns></returns>
        public DatabaseSettingsObj GetCompanyDatabaseSettings(int pCompanyNo, DataBaseType pDbt)
        {
            DatabaseSettingsObj result = null;
            CompanyObj co = ItemNo(pCompanyNo);
            if (co != null)
            {
                string dbName = "";
                switch (pDbt)
	            {
		            case DataBaseType.LiveConfig:
                        dbName = "caLiveConfigurationDB";
                    break;
                    case DataBaseType.LiveEvents:
                        dbName = "caLiveEventsDB";
                    break;
                    case DataBaseType.ComDB:
                        dbName = "caComDB";
                    break;
                    default:
                    break;
	            }
                DatabaseObj dbo = co.DatabaseList.Item(dbName);
                if (dbo != null)
                {
                    result = dbo.Settings;
                }
            }

            return result;
        }
    }
 
}
