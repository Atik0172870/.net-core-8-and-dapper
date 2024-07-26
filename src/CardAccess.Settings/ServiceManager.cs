using System.Data;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;
using Microsoft.Extensions.Logging;

namespace CardAccess.Settings;

public class ServiceManager
{
    public static void ChangeServiceMode(string serviceName, bool startupState)
    {
        try
        {
            ServiceController service = new(serviceName);

            if (service.Status == ServiceControllerStatus.Running && !startupState)
            {
                service.Stop();
                SetServiceStartMode(serviceName, "Disabled");
            }

            if (service.Status == ServiceControllerStatus.Stopped && startupState)
            {
                SetServiceStartMode(serviceName, "Automatic");
                service.Start();
            }
        }
        catch { };
    }

    public static void RestartService(string serviceName)
    {
        try
        {
            ServiceController service = new(serviceName);
            if (service != null)    
            {
                try
                {
                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));
                    }
                }
                catch { }
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
            }
        }
        catch { }
    }

    public static void StartService(string serviceName)
    {
        try
        {
            ServiceController service = new(serviceName);
            service?.Start();
        }
        catch { };
    }

    public static void StartServiceIfNotRunning(string serviceName)
    {
        try
        {
            ServiceController service = new(serviceName);
            if (service != null)
            {
                if (service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
                }
            }
        }
        catch { };
    }

    public static void StopService(string serviceName)
    {
        try
        {
            ServiceController service = new(serviceName);
            service?.Stop();
        }
        catch { };
    }

    public static void SetServiceStartMode(string serviceName, string mode)
    {
        int result = 0;
        try
        {
            string objPath = string.Format("Win32_Service.Name='{0}'", serviceName);
            using var service = new ManagementObject(new ManagementPath(objPath));
            result = Convert.ToInt16(service.InvokeMethod("ChangeStartMode", [mode]));
        }
        catch //(Exception ex)
        {
            result = 1;
        }

        if (result != 0)
        {
            //MessageBox.Show("Error: Failed to update " + ServiceName + " service.");
        }
    }

    public static bool StartProcess(string processName)
    {
        try
        {
            Process p = new();
            string sFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            p.StartInfo.FileName = Path.Combine(sFile, processName);
            p.StartInfo.Verb = "runas";
            p.Start();
            return true;
        }
        catch// (Exception ex)
        {

        }
        return false;
    }
    public static bool KillProcess(string processName)
    {
        try
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
            return true;
        }
        catch //(Exception ex)
        {

        }
        return false;
    }
    public static bool StartLocalSqlServer(bool isLiveServer = false)
    {
        string sqlServiceName = "MSSQLSERVER";
        try
        {
            CardAccessSettings caSettings = new();
            caSettings.LoadEsfFile();
            string comSqlServerName = caSettings.LiveCOMDBServer;
            if (isLiveServer)
                comSqlServerName = caSettings.LiveConfigurationServer;
            if (comSqlServerName.Contains('\\'))
            {
                sqlServiceName = comSqlServerName.Replace(Environment.MachineName + @"\", "MSSQL$");
            }
            //string sqlServiceName = IsExpressSqlServer() ? "MSSQL$SQLEXPRESS" : "MSSQLSERVER";
            ServiceController service = new(sqlServiceName);
            if (service.Status.Equals(ServiceControllerStatus.Stopped) || service.Status.Equals(ServiceControllerStatus.StopPending))
            {
                for (int i = 0; i < 4; i++)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 5, 0));
                    if (!service.Status.Equals(ServiceControllerStatus.Running))
                        System.Threading.Thread.Sleep(15000);
                    else
                        return true;
                }
            }
            return true;
        }
        catch //(Exception ex)
        { }
        return false;
    }

    private static bool StartService(string sqlServiceName, string machineName, ILogger logger)
    {
        try
        {
            ServiceController service = new(sqlServiceName, machineName);
            if (service.Status.Equals(ServiceControllerStatus.Stopped) || service.Status.Equals(ServiceControllerStatus.StopPending))
            {
                for (int i = 0; i < 4; i++)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 5, 0));
                    if (!service.Status.Equals(ServiceControllerStatus.Running))
                        System.Threading.Thread.Sleep(15000);
                    else
                        return true;
                }
            }
        }
        catch (Exception ex)
        {
            logger?.LogError("StartService(sqlServiceName {0}, machineName: {1}) UserName: {2} Error: {3}", sqlServiceName, machineName, Environment.UserName, ex.Message);
            return false;
        }
        return true;
    }
    [CLSCompliant(false)]
    public static bool StartSqlServerByConfigSettings(DataSet dataSet, ILogger logger)
    {
        bool result = false;
        if (dataSet == null) return result;
        try
        {
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                string sqlServiceName = "MSSQLSERVER";
                if (dr["Id"] != DBNull.Value)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    if (id > 0)
                    {
                        string liveConfigServer = dr["LiveConfigServer"].ToString();
                        string machineName = liveConfigServer.Split(@"\".ToCharArray())[0];
                        if (liveConfigServer.Contains('\\'))
                        {
                            sqlServiceName = liveConfigServer.Replace(machineName + @"\", "MSSQL$");
                        }
                        result |= StartService(sqlServiceName, machineName, logger);

                        string liveEventServer = dr["LiveEventServer"].ToString();
                        machineName = liveEventServer.Split(@"\".ToCharArray())[0];
                        if (liveEventServer.Contains('\\'))
                        {
                            sqlServiceName = liveEventServer.Replace(machineName + @"\", "MSSQL$");
                        }
                        result |= StartService(sqlServiceName, machineName, logger);

                        string comServer = dr["ComServer"].ToString();
                        machineName = comServer.Split(@"\".ToCharArray())[0];
                        if (comServer.Contains('\\'))
                        {
                            sqlServiceName = comServer.Replace(machineName + @"\", "MSSQL$");
                        }
                        logger?.LogDebug("Starting sqlServiceName {0}, machineName: {1}", sqlServiceName, machineName);
                        result |= StartService(sqlServiceName, machineName, logger);
                    }
                }
            }
        }
        catch //(Exception ex)
        { }
        return result;
    }
}
