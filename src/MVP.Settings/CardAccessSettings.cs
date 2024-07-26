using System;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
[assembly: CLSCompliant(true)]

namespace MVP.Settings;

/// <summary>
/// COM Interop definition section
/// </summary>
#region COM Interop definition section
[Guid("F8E3F2C2-0CA0-4b3b-94C7-E1E2180DF9A1")]
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
[ComVisible(true)]
[CLSCompliant(true)]
public interface ICardAccessSettings
{
    [DispId(1)]
    void LoadEsfFile();

    [DispId(3)]
    string LiveConfigurationServer { get; set; }

    [DispId(4)]
    string LiveConfigurationDatabase { get; set; }

    [DispId(5)]
    string BusinessServerHost { get; set; }

    [DispId(6)]
    int BusinessServerPort { get; set; }

    [DispId(7)]
    bool AutoStart { get; set; }

    [DispId(8)]
    bool Logging { get; set; }

    [DispId(9)]
    bool UseIntegratedSQLSecurity { get; set; }

    [DispId(10)]
    string LiveEventsServer { get; set; }

    [DispId(11)]
    string LiveEventsDatabase { get; set; }

    [DispId(12)]
    string LiveCOMDBServer { get; set; }

    [DispId(13)]
    string LiveCOMDBDatabase { get; set; }

    [DispId(14)]
    string GenerateDatabaseConnectionString(string sDatabaseServer, string sDatabaseName);

    [DispId(15)]
    string LocalMachineUNCName { get; }

    [DispId(16)]
    void SaveEsfFile();

    [DispId(17)]
    bool Compression { get; set; }

    [DispId(18)]
    bool Encryption { get; set; }

    [DispId(19)]
    int HostHeartbeatInterval { get; set; }

    [DispId(20)]
    int AlertCacheTime { get; set; }

    [DispId(21)]
    int EventCacheTime { get; set; }

    [DispId(22)]
    string IPAddress { get; set; }

    [DispId(23)]
    string DESKey { get; set; }

    [DispId(24)]
    int ProcessorAffinity { get; set; }

    [DispId(25)]
    int MaxAlertCount { get; set; }

    [DispId(26)]
    int AstaADOCommandTimeout { get; set; }

    [DispId(27)]
    int AstaADOConnectionTimeout { get; set; }

    [DispId(28)]
    int DatabaseSessionCount { get; set; }

    [DispId(29)]
    bool UseDateTimeServer { get; set; }

    [DispId(30)]
    string DatabaseUserName { get; set; }

    [DispId(31)]
    string DatabasePassword { get; set; }

    [DispId(32)]
    int AstaPort { get; }

    [DispId(33)]
    bool UseIntegratedSQLSecurityForEvents { get; set; }

    [DispId(34)]
    bool UseIntegratedSQLSecurityForCom { get; set; }


    [DispId(36)]
    string ComDatabasePassword { get; set; }

    [DispId(37)]
    int InstallTypeID { get; set; }

    [DispId(38)]
    string InstallDescription { get; set; }

    [DispId(39)]
    int DataPumpType { get; set; } //0 - service

    [DispId(40)]
    int PollingDelay { get; set; }

    [DispId(41)]
    string LivePortalDatabaseServer { get; set; }

    [DispId(42)]
    string LivePortalDatabase { get; set; }

    [DispId(43)]
    int DefaultDBConfigId { get; set; }
    string LiveCommonMasterDatabaseServer { get; set; }

    string LiveCommonMasterDatabase { get; set; }
    string LiveLoggingDatabaseServer { get; set; }

    string LiveLoggingDatabase { get; set; }
    string EventDatabasePassword { get; set; }
}


[Guid("0B7EF29C-5AEB-4189-831F-F55C7CBF5BB7")]
[ClassInterface(ClassInterfaceType.None)]
[ProgId("MVP.Settings.CardAccessSettings")]
[ComVisible(true)]
#endregion

/// <summary>
/// Called from mbl clientdata/gui mapping datapump and utilities to retrieve settings from encypted xml file
/// </summary>
public class CardAccessSettings : ICardAccessSettings
{
    static readonly bool Is64BitProcess = (IntPtr.Size == 8);
    static readonly bool Is64BitOperatingSystem = Is64BitProcess || InternalCheckIsWow64();

    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWow64Process(
        [In] IntPtr hProcess,
        [Out] out bool wow64Process
    );
    public static bool InternalCheckIsWow64()
    {
        if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
            Environment.OSVersion.Version.Major >= 6)
        {
            using Process p = Process.GetCurrentProcess();
            return IsWow64Process(p.Handle, out bool retVal) && retVal;
        }
        else
        {
            return false;
        }
    }

    const string CSQLConnectionStr_NormalSec = "Provider=SQLOLEDB.1;Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3}";
    const string CSQLConnectionStr_IntSec = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={0};Data Source={1}";

    public CompanyCollection CompanyList { get; set; } = [];

    /// <summary>
    /// This constructor should only be used by 
    /// </summary>
    public CardAccessSettings() => Init();

    private void Init()
    {
        _nAPCOEsf = new XmlDocument();
        PrepareXml();
        AstaServers = new AstaServerList(this);
    }

    public string GenerateDatabaseConnectionString(string sDatabaseServer, string sDatabaseName)
    {
        return UseIntegratedSQLSecurity == true
            ? string.Format(CSQLConnectionStr_IntSec, LiveEventsDatabase, LiveEventsServer)
            : string.Format(CSQLConnectionStr_NormalSec, EventDatabasePassword, DatabaseUserName, LiveEventsDatabase, LiveEventsServer);
    }


    #region Section definition
    public const string DatabaseSection = "DatabaseSection";
    public const string SystemSection = "SystemSection";
    public const string CompanySection = "CompanySection";
    public const string CompanyTag = "Company";
    public const string EpiSection = "EPISection";
    public const string COMSection = "ComSection";
    public const string NAPCOSection = "NAPCOSection";
    public const string GeneralSection = "GeneralSection";
    #endregion
    public const string Ca3000 = "CardAccess.";
    public const string Ext = "xml";

    private readonly byte[] _tdesIV = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08];
    private readonly byte[] _tdeskey = [ 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
            0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18];

    #region Asta Server class definition
    public class AstaServerList
    {
        private readonly CardAccessSettings _settings;

        internal AstaServerList(CardAccessSettings settings) => _settings = settings;
        public int Count
        {
            get
            {
                XmlNode xn = _settings._nAPCOEsf.DocumentElement[SystemSection];
                if (xn != null)
                {
                    XmlNode xn1 = xn["AstaServers"];
                    if (xn1 != null)
                        return xn1.ChildNodes.Count;
                }
                return 0;
            }
        }
        public void Clear()
        {
            XmlNode xn = _settings._nAPCOEsf.DocumentElement[SystemSection];
            if (xn != null)
            {
                if (xn != null)
                {
                    XmlElement xn1 = xn["AstaServers"];
                    xn1?.RemoveAll();
                }
            }
        }
        public AstaServerInfo this[int index]
        {
            get
            {
                XmlElement xn = _settings._nAPCOEsf.DocumentElement[SystemSection];
                if (xn != null)
                {
                    XmlElement xn1 = xn["AstaServers"];
                    if (xn1 == null)
                    {
                        try
                        {
                            xn1 = _settings._nAPCOEsf.CreateElement("AstaServers");
                            xn.AppendChild(xn1);
                        }
                        catch
                        {
                            xn1 = null;
                        }
                    }
                    if (xn1 != null)
                    {
                        try
                        {
                            return new AstaServerInfo(xn1["Server" + index.ToString()]);
                        }
                        catch
                        {
                            XmlNode xn2 = _settings._nAPCOEsf.CreateElement("Server" + index.ToString());
                            xn1.AppendChild(xn2);
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            set
            {
                XmlElement xn = _settings._nAPCOEsf.DocumentElement[SystemSection];
                if (xn != null)
                {
                    XmlElement xn1 = xn["AstaServers"];
                    if (xn1 == null)
                    {
                        try
                        {
                            xn1 = _settings._nAPCOEsf.CreateElement("AstaServers");
                            xn.AppendChild(xn1);
                        }
                        catch
                        {
                            xn1 = null;
                        }
                    }
                    if (xn1 != null)
                    {
                        if (value == null)
                        {
                            if (xn1["Server" + index.ToString()] != null)
                                try
                                {
                                    xn1.RemoveChild(xn1["Server" + index.ToString()]);
                                }
                                catch { }
                        }
                        else
                        {
                            try
                            {
                                if (xn1["Server" + index.ToString()] != null)
                                {
                                    value.SaveInfo(xn1["Server" + index.ToString()]);
                                }
                                else
                                {
                                    XmlNode xn2 = _settings._nAPCOEsf.CreateElement("Server" + index.ToString());
                                    xn1.AppendChild(xn2);
                                    value.SaveInfo(xn2);
                                }
                            }
                            catch
                            {
                                XmlNode xn2 = _settings._nAPCOEsf.CreateElement("Server" + index.ToString());
                                xn1.AppendChild(xn2);
                                value.SaveInfo(xn2);
                            }
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
        }
    }
    public class AstaServerInfo
    {
        private static int GetIntValue(XmlNode n, string valName)
        {
            if (n.Attributes[valName] == null)
                return 0;
            else
            {
                string s = n.Attributes[valName].Value;
                if (string.IsNullOrEmpty(s))
                    return 0;
                else
                    try
                    {
                        return int.Parse(s);
                    }
                    catch
                    {
                        return 0;
                    }
            }
        }
        private static bool GetBoolValue(XmlNode n, string valName)
        {
            if (n.Attributes[valName] == null)
                return false;
            else
            {
                string s = n.Attributes[valName].Value;
                if (string.IsNullOrEmpty(s))
                    return false;
                else
                    try
                    {
                        char c = s.ToUpper()[0];
                        return (c == 'Y' || c == 'T' || c == '1');
                    }
                    catch
                    {
                        return false;
                    }
            }
        }

        public AstaServerInfo() : base() { }
        internal AstaServerInfo(XmlNode xn)
            : this()
        {
            if (xn != null)
            {
                ServerId = GetIntValue(xn, "serverId");
                ServerAddress = xn.Attributes["serverName"] != null ? xn.Attributes["serverName"].Value : "";
                ServerPort = GetIntValue(xn, "serverPort");
                IsAthenaConnection = GetBoolValue(xn, "isAthenaConnection");
                ProtocolType = xn.Attributes["protocoltype"] != null ? xn.Attributes["protocoltype"].Value : "";
                AuthenticationType = xn.Attributes["authenticationtype"] != null ? xn.Attributes["authenticationtype"].Value : "";
            }
        }
        internal static void TrySaveInfo(XmlNode xn, string attribName, string value)
        {
            try
            {
                XmlAttribute attrib = xn.Attributes[attribName];
                if (attrib == null)
                {
                    attrib = xn.OwnerDocument.CreateAttribute(attribName);
                    attrib.Value = value;
                    xn.Attributes.Append(attrib);
                }
                else
                {
                    attrib.Value = value;
                }
            }
            catch
            {
                try
                {
                    XmlAttribute a = xn.OwnerDocument.CreateAttribute(attribName);
                    a.Value = value;
                    xn.Attributes.Append(a);
                }
                catch { }
            }
        }
        internal void SaveInfo(XmlNode xn)
        {
            TrySaveInfo(xn, "serverId", ServerId.ToString());
            TrySaveInfo(xn, "serverName", ServerAddress);
            TrySaveInfo(xn, "serverPort", ServerPort.ToString());
            TrySaveInfo(xn, "isAthenaConnection", IsAthenaConnection.ToString());
            TrySaveInfo(xn, "protocoltype", ProtocolType);
            TrySaveInfo(xn, "authenticationtype", AuthenticationType);
        }

        public int ServerId { get; set; } = 0;
        public string ServerAddress { get; set; } = "";
        public int ServerPort { get; set; } = 9000;
        public bool IsAthenaConnection { get; set; } = false;
        public string ProtocolType { get; set; } = "TCP";
        public string AuthenticationType { get; set; } = "WindowsAuthentication";
    }

    public AstaServerList AstaServers { get; set; }
    public int AstaPort
    {
        get
        {
            int port = 9000;
            for (int i = 0; i < AstaServers.Count; i++)
            {
                AstaServerInfo info = AstaServers[i];
                if (info != null)
                {
                    if (info.ServerAddress == "127.0.0.1")
                        port = info.ServerPort;
                }
            }
            return port;
        }
    }
    #endregion
    public string CICProtocolType
    {
        get
        {
            string protocoltype = "TCP";
            for (int i = 0; i < AstaServers.Count; i++)
            {
                AstaServerInfo info = AstaServers[i];
                if (info != null)
                {
                    protocoltype = info.ProtocolType;
                }
            }
            return protocoltype;
        }
    }
    #region Loading And Saving to XML File
    public void LoadEsfFile()
    {
        LoadEsfFileFrom(Ca3000 + Ext);
    }

    public void SaveEsfFile()
    {
        SaveEsfFileTo(Ca3000 + Ext);
    }
    #endregion
    #region Public Properties
    #region CICDataServer Properties
    public bool AutoStart
    {
        get => ReadBool(SystemSection, nameof(AutoStart), true);
        set => WriteBool(SystemSection, nameof(AutoStart), value);
    }
    public bool Logging
    {
        get => ReadBool(SystemSection, nameof(Logging), true);
        set => WriteBool(SystemSection, nameof(Logging), value);
    }
    public bool Compression
    {
        get => ReadBool(SystemSection, nameof(Compression), false);
        set => WriteBool(SystemSection, nameof(Compression), value);
    }
    public bool Encryption
    {
        get => ReadBool(SystemSection, nameof(Encryption), false);
        set => WriteBool(SystemSection, nameof(Encryption), value);
    }
    public int HostHeartbeatInterval
    {
        get => ReadInt32(SystemSection, nameof(HostHeartbeatInterval), 10);
        set => WriteInt32(SystemSection, nameof(HostHeartbeatInterval), value);
    }
    public int AlertCacheTime
    {
        get => ReadInt32(SystemSection, nameof(AlertCacheTime), 1000); 
        set => WriteInt32(SystemSection, nameof(AlertCacheTime), value);
    }
    public int EventCacheTime
    {
        get => ReadInt32(SystemSection, nameof(EventCacheTime), 5000); 
        set => WriteInt32(SystemSection, nameof(EventCacheTime), value);
    }
    public string IPAddress
    {
        get => ReadString(SystemSection, nameof(IPAddress));
        set => WriteString(SystemSection, nameof(IPAddress), value);
    }
    public string DESKey
    {
        get => ReadString(SystemSection, nameof(DESKey)); set => WriteString(SystemSection, nameof(DESKey), value);
    }
    public int ProcessorAffinity
    {
        get => ReadInt32(SystemSection, nameof(ProcessorAffinity), -1); set => WriteInt32(SystemSection, nameof(ProcessorAffinity), value);
    }
    public int MaxAlertCount
    {
        get => ReadInt32(SystemSection, nameof(MaxAlertCount), 1000); set => WriteInt32(SystemSection, nameof(MaxAlertCount), value);
    }
    public int AstaADOCommandTimeout
    {
        get => ReadInt32(SystemSection, nameof(AstaADOCommandTimeout), 360); set => WriteInt32(SystemSection, nameof(AstaADOCommandTimeout), value);
    }
    public int AstaADOConnectionTimeout
    {
        get => ReadInt32(SystemSection, nameof(AstaADOConnectionTimeout), 120); set => WriteInt32(SystemSection, nameof(AstaADOConnectionTimeout), value);
    }
    public int DatabaseSessionCount
    {
        get => ReadInt32(SystemSection, nameof(DatabaseSessionCount)); set => WriteInt32(SystemSection, nameof(DatabaseSessionCount), value);
    }
    public bool UseDateTimeServer
    {
        get => ReadBool(SystemSection, nameof(UseDateTimeServer), false); set => WriteBool(SystemSection, nameof(UseDateTimeServer), value);
    }
    #endregion

    #region Business Server Properties
    public string BusinessServerHost
    {
        get => ReadString(SystemSection, nameof(BusinessServerHost)); set => WriteString(SystemSection, nameof(BusinessServerHost), value);
    }
    public int BusinessServerPort
    {
        get => ReadInt32(SystemSection, nameof(BusinessServerPort), 9001); set => WriteInt32(SystemSection, nameof(BusinessServerPort), value);
    }
    public int MaxConnectionRetries
    {
        get => ReadInt32(SystemSection, nameof(MaxConnectionRetries), 3); set => WriteInt32(SystemSection, nameof(MaxConnectionRetries), value);
    }
    #endregion
    #region Messaging Server Ports

    public int MessagingTCPPort
    {
        get => ReadInt32(SystemSection, nameof(MessagingTCPPort), 9000); set => WriteInt32(SystemSection, nameof(MessagingTCPPort), value);
    }
    public int MessagingHTTPPort
    {
        get => ReadInt32(SystemSection, nameof(MessagingHTTPPort), 9091); set => WriteInt32(SystemSection, nameof(MessagingHTTPPort), value);
    }
    public string MessagingNETPIPEPort
    {
        get => ReadString(SystemSection, nameof(MessagingNETPIPEPort)); set => WriteString(SystemSection, nameof(MessagingNETPIPEPort), value);
    }


    public string AuthenticationTypeTCP
    {
        get => ReadString(SystemSection, nameof(AuthenticationTypeTCP)); set => WriteString(SystemSection, nameof(AuthenticationTypeTCP), value);
    }
    public string AuthenticationTypeHTTP
    {
        get => ReadString(SystemSection, nameof(AuthenticationTypeHTTP)); set => WriteString(SystemSection, nameof(AuthenticationTypeHTTP), value);
    }
    public string AuthenticationTypeNETPIPE
    {
        get => ReadString(SystemSection, nameof(AuthenticationTypeNETPIPE)); set => WriteString(SystemSection, nameof(AuthenticationTypeNETPIPE), value);
    }

    #endregion

    #region Password Settings
    public int PasswordMinLength
    {
        get => ReadInt32(SystemSection, nameof(PasswordMinLength), 1); set => WriteInt32(SystemSection, nameof(PasswordMinLength), value);
    }
    public int PasswordMaxLength
    {
        get => ReadInt32(SystemSection, nameof(PasswordMaxLength), 20); set => WriteInt32(SystemSection, nameof(PasswordMaxLength), value);
    }
    public int PasswordMinNonAlphaChars
    {
        get => ReadInt32(SystemSection, nameof(PasswordMinNonAlphaChars), 0); set => WriteInt32(SystemSection, nameof(PasswordMinNonAlphaChars), value);
    }
    public string PasswordRegEx
    {
        get => ReadString(SystemSection, nameof(PasswordRegEx)); set => WriteString(SystemSection, nameof(PasswordRegEx), value);
    }
    #endregion
    #region Database Properties
    public int DBServiceInterval
    {
        get => ReadInt32(DatabaseSection, nameof(DBServiceInterval), 4);
        set => WriteInt32(DatabaseSection, nameof(DBServiceInterval), value);
    }
    public string LiveConfigurationServer
    {
        get => ReadString(DatabaseSection, nameof(LiveConfigurationServer));
        set => WriteString(DatabaseSection, nameof(LiveConfigurationServer), value);
    }

    public string LivePortalDatabaseServer
    {
        get => ReadString(DatabaseSection, nameof(LivePortalDatabaseServer));
        set => WriteString(DatabaseSection, nameof(LivePortalDatabaseServer), value);
    }
    public string LivePortalDatabase
    {
        get => ReadString(DatabaseSection, nameof(LivePortalDatabase));
        set => WriteString(DatabaseSection, nameof(LivePortalDatabase), value);
    }

    public string LiveCommonMasterDatabaseServer
    {
        get => ReadString(DatabaseSection, nameof(LiveCommonMasterDatabaseServer));
        set => WriteString(DatabaseSection, nameof(LiveCommonMasterDatabaseServer), value);
    }
    public string LiveCommonMasterDatabase
    {
        get => ReadString(DatabaseSection, nameof(LiveCommonMasterDatabase));
        set => WriteString(DatabaseSection, nameof(LiveCommonMasterDatabase), value);
    }

    public string LiveLoggingDatabaseServer
    {
        get => ReadString(DatabaseSection, nameof(LiveLoggingDatabaseServer));
        set => WriteString(DatabaseSection, nameof(LiveLoggingDatabaseServer), value);
    }
    public string LiveLoggingDatabase
    {
        get => ReadString(DatabaseSection, nameof(LiveLoggingDatabase));
        set => WriteString(DatabaseSection, nameof(LiveLoggingDatabase), value);
    }

    public string LiveConfigurationDatabase
    {
        get => ReadString(DatabaseSection, nameof(LiveConfigurationDatabase));
        set => WriteString(DatabaseSection, nameof(LiveConfigurationDatabase), value);
    }
    public string LiveEventsServer
    {
        get => ReadString(DatabaseSection, nameof(LiveEventsServer));
        set => WriteString(DatabaseSection, nameof(LiveEventsServer), value);
    }
    public string LiveEventsDatabase
    {
        get => ReadString(DatabaseSection, nameof(LiveEventsDatabase));
        set => WriteString(DatabaseSection, nameof(LiveEventsDatabase), value);
    }
    public string LiveCOMDBServer
    {
        get => ReadString(DatabaseSection, nameof(LiveCOMDBServer));
        set => WriteString(DatabaseSection, nameof(LiveCOMDBServer), value);
    }
    public string LiveCOMDBDatabase
    {
        get => ReadString(DatabaseSection, nameof(LiveCOMDBDatabase));
        set => WriteString(DatabaseSection, nameof(LiveCOMDBDatabase), value);
    }
    public string DatabasePassword
    {
        get => ReadString(DatabaseSection, nameof(DatabasePassword));
        set => WriteString(DatabaseSection, nameof(DatabasePassword), value);
    }
    public string DatabaseUserName
    {
        get => ReadString(DatabaseSection, nameof(DatabaseUserName));
        set => WriteString(DatabaseSection, nameof(DatabaseUserName), value);
    }
    public string EventDatabasePassword
    {
        get => ReadString(DatabaseSection, nameof(EventDatabasePassword));
        set => WriteString(DatabaseSection, nameof(EventDatabasePassword), value);
    }

    public bool UseIntegratedSQLSecurity
    {
        get => ReadBool(DatabaseSection, nameof(UseIntegratedSQLSecurity), false);
        set => WriteBool(DatabaseSection, nameof(UseIntegratedSQLSecurity), value);
    }

    public bool UseIntegratedSQLSecurityForEvents
    {
        get => ReadBool(DatabaseSection, nameof(UseIntegratedSQLSecurityForEvents), false);
        set => WriteBool(DatabaseSection, nameof(UseIntegratedSQLSecurityForEvents), value);
    }

    public bool UseIntegratedSQLSecurityForCom
    {
        get => ReadBool(DatabaseSection, nameof(UseIntegratedSQLSecurityForCom), false);
        set => WriteBool(DatabaseSection, nameof(UseIntegratedSQLSecurityForCom), value);
    }


    public string ComDatabasePassword
    {
        get => ReadString(DatabaseSection, nameof(ComDatabasePassword));
        set => WriteString(DatabaseSection, nameof(ComDatabasePassword), value);
    }

    public DatabaseTechnology DatabaseTechnology
    {
        get => ReadInt32(DatabaseSection, nameof(DatabaseTechnology)) == 1 ? DatabaseTechnology.Oracle : DatabaseTechnology.SQL2005;
        set
        {
            switch (value)
            {
                case DatabaseTechnology.Oracle: WriteInt32(DatabaseSection, nameof(DatabaseTechnology), 1); break;
                default: WriteInt32(DatabaseSection, nameof(DatabaseTechnology), 0); break;
            }
        }
    }
    public int ArchiveEventChunk
    {
        get => ReadInt32(DatabaseSection, nameof(ArchiveEventChunk), 300); set => WriteInt32(DatabaseSection, nameof(ArchiveEventChunk), value);
    }
    public int ArchiveSleepTime
    {
        get => ReadInt32(DatabaseSection, nameof(ArchiveSleepTime), 1500); set => WriteInt32(DatabaseSection, nameof(ArchiveSleepTime), value);
    }
    public int ArchiveTimeLimit
    {
        get => ReadInt32(DatabaseSection, nameof(ArchiveTimeLimit), 10); set => WriteInt32(DatabaseSection, nameof(ArchiveTimeLimit), value);

    }
    #endregion

    public int Language
    {
        get => ReadInt32(SystemSection, nameof(Language));
        set
        {
            _xSystem = _nAPCOEsf.DocumentElement[SystemSection];
            if (_xSystem != null)
            {
                _xSystem["Language"].InnerText = value.ToString();
            }
            else
            {
            }
        }
    }
    public string LocalMachineUNCName => Environment.MachineName.Trim().ToUpper();
    public string WorkstationName
    {
        get => ReadString(SystemSection, nameof(WorkstationName)); set => WriteString(SystemSection, nameof(WorkstationName), value);
    }

    #region EPI Settings
    public string OdbcConnetionName
    {
        get => ReadString(EpiSection, "ODBCConnetionName", "Badging");
        set
        => WriteString(EpiSection, "ODBCConnetionName", value);
    }
    public string EpiLicenseFile
    {
        get
        {
            string epiLicPath = @"C:\Program Files (x86)\ImageWare Systems\EPIBUILDER\6\EPIRT.lic";
            return ReadString(EpiSection, "EPILicenseFile", Is64BitOperatingSystem ? epiLicPath : epiLicPath.Replace(" (x86)", ""));
        }
        set
        => WriteString(EpiSection, "EPILicenseFile", value);
    }
    public string EpiLayoutPath
    {
        get => ReadString(EpiSection, "EPILayoutPath");
        set => WriteString(EpiSection, "EPILayoutPath", value);
    }
    public string EpiDesignerPath
    {
        get
        {
            string epiDesignerPath = @"C:\Program Files (x86)\ImageWare Systems\EPIBUILDER\6\EPIDesigner.exe";
            return ReadString(EpiSection, "EPIDesignerPath", Is64BitOperatingSystem ? epiDesignerPath : epiDesignerPath.Replace(" (x86)", ""));
        }
        set => WriteString(EpiSection, "EPIDesignerPath", value);
    }
    #endregion
    #region Com Server Settings
    public int QueryInterval
    {
        get => ReadInt32(COMSection, nameof(QueryInterval), 8);
        set => WriteInt32(COMSection, nameof(QueryInterval), value);
    }
    public int LANTimeout
    {
        get
        => ReadInt32(COMSection, "LanTimeout", 4);
        set => WriteInt32(COMSection, "LanTimeout", value);
    }
    public int APBBroadcastWaitTime
    {
        get
        => ReadInt32(COMSection, "ApbBroadcastWaitTime", 25);
        set
        => WriteInt32(COMSection, "ApbBroadcastWaitTime", value);
    }
    #endregion
    #region Napco Integration
    public int NAPCOCommandDelay
    {
        get
        => ReadInt32(NAPCOSection, "NapcoCommandDelay", 6000);
        set
        => WriteInt32(NAPCOSection, "NapcoCommandDelay", value);
    }
    #endregion
    #region General
    public bool USESplashScreen
    {
        get
        => ReadBool(GeneralSection, "UseSplashScreen", true);
        set
        => WriteBool(GeneralSection, "UseSplashScreen", value);
    }

    //0 - FullInstall, 1 - DBSErver, 2 - HCS, 4 - Workstation, 5 - Server
    public int InstallTypeID
    {
        get
        => ReadInt32(GeneralSection, nameof(InstallTypeID), 0);
        set
        => WriteInt32(GeneralSection, nameof(InstallTypeID), value);
    }

    public string InstallDescription
    {
        get
        => ReadString(GeneralSection, nameof(InstallDescription));
        set
        => WriteString(GeneralSection, nameof(InstallDescription), value);
    }

    //0 - service
    public int DataPumpType
    {
        get
        => ReadInt32(GeneralSection, nameof(DataPumpType), 0);
        set
        => WriteInt32(GeneralSection, nameof(DataPumpType), value);
    }

    public int PollingDelay
    {
        get
        => ReadInt32(GeneralSection, nameof(PollingDelay), 10);
        set
        => WriteInt32(GeneralSection, nameof(PollingDelay), value);
    }

    public bool EnableWirelessLockService
    {
        get => ReadBool(GeneralSection, nameof(EnableWirelessLockService), false);
        set => WriteBool(GeneralSection, nameof(EnableWirelessLockService), value);
    }
    public bool EnableNapcoService
    {
        get => ReadBool(GeneralSection, nameof(EnableNapcoService), false);
        set => WriteBool(GeneralSection, nameof(EnableNapcoService), value);
    }
    public bool EnableScriptingService
    {
        get => ReadBool(GeneralSection, nameof(EnableScriptingService), false);
        set => WriteBool(GeneralSection, nameof(EnableScriptingService), value);
    }
    public bool EnableVideoService
    {
        get => ReadBool(GeneralSection, nameof(EnableVideoService), false);
        set => WriteBool(GeneralSection, nameof(EnableVideoService), value);
    }
    public bool EnableEventActionService
    {
        get => ReadBool(GeneralSection, nameof(EnableEventActionService), false);
        set => WriteBool(GeneralSection, nameof(EnableEventActionService), value);
    }

    public int DefaultDBConfigId // Read from PortalDB ConfigurationSettings Table. To Identify application DB type AirAccess, ContiHosting etc. 
    {
        get
        => ReadInt32(GeneralSection, nameof(DefaultDBConfigId), 2);
        set
        => WriteInt32(GeneralSection, nameof(DefaultDBConfigId), value);
    }

    #endregion
    #region Internal Read/Write
    internal protected bool ReadBool(string sectionName, string propertyName)
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            try
            {
                XmlNode xn1;
                xn1 = xn[propertyName];
                if (xn1 != null)
                {
                    return Convert.ToBoolean(xn[propertyName].InnerText);
                }
                else
                {
                    xn1 = _nAPCOEsf.CreateElement(propertyName);
                    xn.AppendChild(xn1);
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    internal protected bool ReadBool(string sectionName, string propertyName, bool defaultValue)
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            try
            {
                XmlNode xn1;
                xn1 = xn[propertyName];
                if (xn1 != null)
                {
                    return string.IsNullOrEmpty(xn[propertyName].InnerText) ? defaultValue : Convert.ToBoolean(xn[propertyName].InnerText);
                }
                else
                {
                    xn1 = _nAPCOEsf.CreateElement(propertyName);
                    xn.AppendChild(xn1);
                    return defaultValue;
                }
            }
            catch (FormatException)
            {
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
        else
        {
            return defaultValue;
        }
    }
    internal protected Int32 ReadInt32(string sectionName, string propertyName, int defaultValue)
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            try
            {
                XmlNode xn1;
                xn1 = xn[propertyName];
                if (xn1 != null)
                {
                    return string.IsNullOrEmpty(xn[propertyName].InnerText) ? defaultValue : Convert.ToInt32(xn[propertyName].InnerText);
                }
                else
                {
                    xn1 = _nAPCOEsf.CreateElement(propertyName);
                    xn.AppendChild(xn1);
                    return defaultValue;
                }
            }
            catch (FormatException)
            {
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
        else
        {
            return defaultValue;
        }
    }
    internal protected Int32 ReadInt32(string sectionName, string propertyName)
    {
        return ReadInt32(sectionName, propertyName, 0);
    }
    internal protected string ReadString(string sectionName, string propertyName, string defaultValue = "")
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            try
            {
                XmlNode xn1;
                xn1 = xn[propertyName];
                if (xn1 != null)
                {
                    return !string.IsNullOrEmpty(xn[propertyName].InnerText) ? xn[propertyName].InnerText : defaultValue;
                }
                else
                {
                    xn1 = _nAPCOEsf.CreateElement(propertyName);
                    xn.AppendChild(xn1);
                    return defaultValue;
                }
            }
            catch (FormatException)
            {
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
        else
        {
            return defaultValue;
        }
    }
    internal protected void WriteBool(string sectionName, string propertyName, bool value)
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            XmlNode xn1;
            xn1 = xn[propertyName];
            if (xn1 == null)
            {
                xn1 = _nAPCOEsf.CreateElement(propertyName);
                xn.AppendChild(xn1);
            }
            xn[propertyName].InnerText = value.ToString();
        }
        else
        {
        }
    }
    internal protected void WriteInt32(string sectionName, string propertyName, int value)
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            XmlNode xn1;
            xn1 = xn[propertyName];
            if (xn1 == null)
            {
                xn1 = _nAPCOEsf.CreateElement(propertyName);
                xn.AppendChild(xn1);
            }
            xn[propertyName].InnerText = value.ToString();
        }
        else
        {
        }
    }
    internal protected void WriteString(string sectionName, string propertyName, string value)
    {
        XmlElement xn = _nAPCOEsf.DocumentElement[sectionName];
        if (xn != null)
        {
            XmlNode xn1;
            xn1 = xn[propertyName];
            if (xn1 == null)
            {
                xn1 = _nAPCOEsf.CreateElement(propertyName);
                xn.AppendChild(xn1);
            }
            xn[propertyName].InnerText = value;
        }
        else
        {
        }
    }
    #endregion
    #region Private Variables/Methods
    private XmlDocument _nAPCOEsf;
    private XmlElement _xDatabase;
    private XmlElement _xCompany;
    private XmlElement _xSystem;
    private XmlElement _xEPI;
    private XmlElement _xCom;
    private XmlElement _xNAPCO;
    private XmlElement _xGeneral;

    protected virtual void AddDefaultSections()
    {
        AddSystemSection();
        AddDatabaseSection();
        AddEPISection();
        AddCOMSection();
        AddNAPCOSection();
        AddGeneralSection();
    }

    private void AddDatabaseSection()
    {
        XmlNode xn;

        _xDatabase = _nAPCOEsf.CreateElement(DatabaseSection);
        _xDatabase.InnerText = DatabaseSection;
        _nAPCOEsf.DocumentElement.AppendChild(_xDatabase);

        xn = _nAPCOEsf.CreateElement("LiveConfigurationServer");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LivePortalDatabaseServer");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LivePortalDatabase");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LiveConfigurationDatabase");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LiveEventsServer");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LiveEventsDatabase");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LiveCOMDBServer");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LiveCOMDBDatabase");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("ComDatabasePassword");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("DBServiceInterval");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("DatabaseServerName");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("DatabaseName");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("DatabaseUserName");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("DatabasePassword");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EventDatabasePassword");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("UseIntegratedSQLSecurity");
        _xDatabase.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("ArchiveSleepTime");
        _xDatabase.AppendChild(xn);
        xn = _nAPCOEsf.CreateElement("ArchiveEventChunk");
        _xDatabase.AppendChild(xn);
        xn = _nAPCOEsf.CreateElement("ArchiveTimeLimit");
        _xDatabase.AppendChild(xn);

    }
    private void AddSystemSection()
    {
        XmlNode xn;

        _xSystem = _nAPCOEsf.CreateElement(SystemSection);
        _xSystem.InnerText = SystemSection;
        _nAPCOEsf.DocumentElement.AppendChild(_xSystem);


        xn = _nAPCOEsf.CreateElement("AstaServers");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("BusinessServerHost");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("BusinessServerPort");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("MessagingTCPPort");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("MessagingHTTPPort");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("MessagingNETPIPEPort");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("AuthenticationTypeTCP");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("AuthenticationTypeHTTP");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("AuthenticationTypeNETPIPE");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("PasswordMinLength");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("PasswordMaxLength");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("PasswordMinNonAlphaChars");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("PasswordRegEx");
        _xSystem.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("WorkstationName");
        _xSystem.AppendChild(xn);

    }
    private void AddEPISection()
    {
        XmlNode xn;

        _xEPI = _nAPCOEsf.CreateElement(EpiSection);
        _xEPI.InnerText = EpiSection;
        _nAPCOEsf.DocumentElement.AppendChild(_xEPI);

        xn = _nAPCOEsf.CreateElement("ODBCConnectionName");
        _xEPI.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EPILicenseFile");
        _xEPI.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EPILayoutPath");
        _xEPI.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EPIDesignerPath");
        _xEPI.AppendChild(xn);
    }
    private void AddCOMSection()
    {
        XmlNode xn;

        _xCom = _nAPCOEsf.CreateElement(COMSection);
        _xCom.InnerText = COMSection;
        _nAPCOEsf.DocumentElement.AppendChild(_xCom);

        xn = _nAPCOEsf.CreateElement("QueryInterval");
        _xCom.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("LanTimeout");
        _xCom.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("ApbBroadcastWaitTime");
        _xCom.AppendChild(xn);
    }
    private void AddNAPCOSection()
    {
        XmlNode xn;

        _xNAPCO = _nAPCOEsf.CreateElement(NAPCOSection);
        _xNAPCO.InnerText = NAPCOSection;
        _nAPCOEsf.DocumentElement.AppendChild(_xNAPCO);

        xn = _nAPCOEsf.CreateElement("NapcoCommandDelay");
        _xNAPCO.AppendChild(xn);
    }
    private void AddGeneralSection()
    {
        XmlNode xn;

        _xGeneral = _nAPCOEsf.CreateElement(GeneralSection);
        _xGeneral.InnerText = GeneralSection;
        _nAPCOEsf.DocumentElement.AppendChild(_xGeneral);

        xn = _nAPCOEsf.CreateElement("UseSplashScreen");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("InstallTypeID");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("InstallDescription");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("DataPumpType");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("PollingDelay");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EnableWirelessLockService");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EnableNapcoService");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EnableScriptingService");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EnableVideoService");
        _xGeneral.AppendChild(xn);

        xn = _nAPCOEsf.CreateElement("EnableEventActionService");
        _xGeneral.AppendChild(xn);
    }

    const string DEFAULT_USR = "cic";
    const string DEFAULT_PSW = "Cic!23456789";

    public void SetDefaultSecurity()
    {
        this.DatabaseUserName = DEFAULT_USR;
        this.DatabasePassword = DEFAULT_PSW;
        this.UseIntegratedSQLSecurity = false;

        this.EventDatabasePassword = DEFAULT_PSW;
        this.UseIntegratedSQLSecurityForEvents = false;

        this.ComDatabasePassword = DEFAULT_PSW;
        this.UseIntegratedSQLSecurityForCom = false;
    }

    public string GetXmlFileData()
    {
        return _nAPCOEsf != null ? _nAPCOEsf.InnerXml : "";
    }

    public void LoadEsfFileFrom(string fileName)
    {
        string filePath;
        filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CardAccess");
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        string fullFileName = Path.Combine(filePath, fileName);
        //Check to see if the file exists or not
        if (File.Exists(fullFileName))
        {
            FileStream fin = new(fullFileName, FileMode.Open, FileAccess.Read);

            MemoryStream ms = new();

            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;     //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.

#pragma warning disable SYSLIB0021 // Type or member is obsolete
            TripleDESCryptoServiceProvider tdes = new()
            {
#pragma warning restore SYSLIB0021 // Type or member is obsolete
                Padding = PaddingMode.Zeros
            };
            CryptoStream dencStream = new(ms, tdes.CreateDecryptor(_tdeskey, _tdesIV), CryptoStreamMode.Write);

            try
            {
                //Read from the input file, then decrypt and write to the output stream.
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    dencStream.Write(bin, 0, len);
                    rdlen += len;
                }

                ms.Position = 0;

                byte[] tb = new byte[ms.Length];
                ms.Read(tb, 0, (int)ms.Length);

                int n = 7;
                Int64 n64 = 0;
                while (n >= 0)
                {
                    n64 += (tb[n] << (n * 8));
                    n--;
                }
                ms.SetLength(0);
                ms.Write(tb, 8, (int)n64);

                /*            #region Optional2
                            ms.Position = 0;
                            FileStream fs = new FileStream("C:\\Temp\\fileO.xml", FileMode.Create, FileAccess.ReadWrite);
                            byte[] bb = new byte[(int)ms.Length];
                            ms.Read(bb, 0, (int)ms.Length);
                            fs.Write(bb, 0, (int)ms.Length);
                            ms.Position = 0;
                            fs.Close();
                            #endregion
                */
                ms.Position = 0;

                XmlTextReader reader = new(ms)
                {
                    WhitespaceHandling = WhitespaceHandling.None
                };
                reader.Read();
                _nAPCOEsf.Load(reader);
                reader.Close();
            }
            finally
            {
                fin.Close();
            }
            //if the document is blank just add the first node and the known sections
            PrepareXml();
            LoadCompanies();
        }
        else
        {
            //throw(new FileNotFoundException(FilePath+FileName));
        }
    }
    private void PrepareXml()
    {
        if (_nAPCOEsf.DocumentElement == null)
        {
            XmlNode xn;

            //xn = NAPCOEsf.CreateNode(System.Xml.XmlNodeType.DocumentType, "Configuration","");
            //NAPCOEsf.AppendChild(xn);

            xn = _nAPCOEsf.CreateElement("NAPCOConfig");
            //xn.InnerText = "NAPCO Configuration File";
            _nAPCOEsf.AppendChild(xn);

            AddDefaultSections();
        }
        else
        {
            XmlNode xn = _nAPCOEsf.DocumentElement.FirstChild;
            if (xn == null)
            {
                //add all the sections here
                AddDefaultSections();
            }
        }
    }
    private void SaveEsfFileTo(string fileName)
    {
        string filePath;
        filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CardAccess");
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        string fullFileName = Path.Combine(filePath, fileName);
        if (File.Exists(fullFileName))
        {
            File.Copy(fullFileName, Path.ChangeExtension(fullFileName, ".bak"), true);
        }
        PrepareXml();
        FileStream fout = new(fullFileName, FileMode.OpenOrCreate, FileAccess.Write);

        MemoryStream ms = new();
        XmlTextWriter writer = new(ms, System.Text.Encoding.UTF8)
        {
            Formatting = Formatting.Indented
        };
        _nAPCOEsf.Save(writer);

        /*        #region Oprional1
                ms.Position = 0;
                FileStream fs = new FileStream("C:\\Temp\\fileI.xml", FileMode.Create, FileAccess.ReadWrite);
                byte[] bb = new byte[(int)ms.Length];
                ms.Read(bb, 0, (int)ms.Length);
                fs.Write(bb, 0, (int)ms.Length);
                ms.Position = 0;
                fs.Close();
                #endregion
        */
        ms.Position = 0;

        //Now pad the data size
        byte[] tb = new byte[ms.Length + 8];
        ms.Read(tb, 8, (int)ms.Length);

        int n = 7;
        while (n >= 0)
        {
            tb[n] = Convert.ToByte((ms.Length >> (n * 8)) & 255);
            n--;
        }
        ms.SetLength(0);
        ms.Write(tb, 0, tb.GetLength(0));

        //Create variables to help with read and write.
        byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
        long rdlen = 0;              //This is the total number of bytes written.
        long totlen = ms.Length;     //This is the total length of the input file.
        int len;                     //This is the number of bytes to be written at a time.

        ms.Position = 0;
#pragma warning disable SYSLIB0021 // Type or member is obsolete
        TripleDESCryptoServiceProvider tdes = new()
        {
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            Padding = PaddingMode.Zeros
        };
        CryptoStream encStream = new(fout, tdes.CreateEncryptor(_tdeskey, _tdesIV), CryptoStreamMode.Write);

        //Read from the input file, then encrypt and write to the output file.
        while (rdlen < totlen)
        {
            len = ms.Read(bin, 0, 100);
            encStream.Write(bin, 0, len);
            rdlen += len;
        }

        encStream.Close();
        //writer.Flush();
        //writer.Close();
    }

    #endregion
    #region CompanyList

    /// <summary>
    /// saves company collection to xml file
    /// </summary>
    public void SaveCompanies()
    {
        _xCompany = _nAPCOEsf.DocumentElement[CompanySection];
        if (_xCompany == null)
        {
            _xCompany = _nAPCOEsf.CreateElement(CompanySection);
            _nAPCOEsf.DocumentElement.AppendChild(_xCompany);
        }

        if (_xCompany != null)
        {
            _xCompany.InnerXml = "";

            foreach (CompanyObj compObj in CompanyList)
            {
                XmlElement xnRoot = _nAPCOEsf.CreateElement(CompanyTag);
                XmlAttribute attribute = null;

                attribute = _nAPCOEsf.CreateAttribute("Number");
                attribute.Value = compObj.CompanyNumber.ToString();
                xnRoot.Attributes.Append(attribute);

                attribute = _nAPCOEsf.CreateAttribute("Name");
                attribute.Value = compObj.CompanyName;
                xnRoot.Attributes.Append(attribute);

                _xCompany.AppendChild(xnRoot);

                foreach (DatabaseObj dbObj in compObj.DatabaseList)
                {
                    XmlElement xnDB = _nAPCOEsf.CreateElement(dbObj.DatabaseName);
                    xnRoot.AppendChild(xnDB);

                    XmlNode xn = _nAPCOEsf.CreateElement("server");
                    xn.InnerText = dbObj.Settings.Server;
                    xnDB.AppendChild(xn);

                    xn = _nAPCOEsf.CreateElement("database");
                    xn.InnerText = dbObj.Settings.Database;
                    xnDB.AppendChild(xn);

                    xn = _nAPCOEsf.CreateElement("user");
                    xn.InnerText = dbObj.Settings.User;
                    xnDB.AppendChild(xn);

                    xn = _nAPCOEsf.CreateElement("password");
                    xn.InnerText = dbObj.Settings.Password;
                    xnDB.AppendChild(xn);
                }
            }
            SaveEsfFileTo(Ca3000 + Ext);

        }
    }
    /// <summary>
    /// Loads Company collection from xml file
    /// </summary>
    private void LoadCompanies()
    {
        _xCompany = _nAPCOEsf.DocumentElement[CompanySection];
        if (_xCompany != null)
        {
            foreach (XmlNode xn in _xCompany.ChildNodes)
            {
                CompanyObj compObj = CompanyList.AddCompany(xn.Attributes["Name"].Value, Convert.ToInt32(xn.Attributes["Number"].Value));
                foreach (XmlNode xn1 in xn.ChildNodes)
                {
                    compObj.DatabaseList.AddDatabase(xn1.Name, xn1.ChildNodes[0].InnerText, xn1.ChildNodes[1].InnerText, xn1.ChildNodes[2].InnerText, xn1.ChildNodes[3].InnerText);
                }
            }
        }

    }
    #endregion
    #endregion

    public string GetLivePortalDatabaseServer(string configDbServer)
    {
        string result = string.Empty;
        if (!LivePortalDatabaseServer.Trim().ToLower().Equals(configDbServer.Trim().ToLower()))
            result = LivePortalDatabaseServer;
        return result;
    }
}
/// <summary>
/// DB Vendor Type
/// </summary>
public enum DatabaseTechnology { SQL2005, SQL2008, Oracle }
